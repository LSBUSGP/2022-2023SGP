using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarHandler : MonoBehaviour
{
    public GameObject RadarObjectHolder;
    public GameObject Camera;
    private Transform HolderTransform;

    void Start()
    {
        HolderTransform = RadarObjectHolder.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Camera.transform.eulerAngles.y;

        if (y > 180)
        {
            y = y - 360;
        }

        // y = y / 360;

        HolderTransform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, y);



        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.activeInHierarchy)
            {
                if (go.GetComponent<RadarContact>())
                {
                    if ((go.transform.position - gameObject.transform.position).magnitude < 30.0f)
                    {
                        float mag = (go.transform.position - gameObject.transform.position).magnitude;
                        Vector3 plot = (go.transform.position - gameObject.transform.position) * 3;


                        if (HolderTransform.Find(go.name)) {
                            HolderTransform.Find(go.name).GetComponent<RectTransform>().localPosition = new Vector3(plot.x, plot.z, 0);
                        }
                        else
                        {
                            GameObject Object = HolderTransform.Find("MainCharacter").gameObject;
                            Object = Instantiate(Object, HolderTransform);
                            Object.name = go.name;
                            Object.GetComponent<RectTransform>().localPosition = new Vector3(plot.x, plot.z, 0);
                        }
                    }
                    else
                    {
                        if (RadarObjectHolder.transform.Find(go.name)) {
                            Destroy(RadarObjectHolder.transform.Find(go.name), 0);
                        }
                    }
                }
            }
        }
    }
}
