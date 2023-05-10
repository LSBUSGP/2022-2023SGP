using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private Vector3 SpawnPoint = new Vector3(0, 0, 226);
    public GameObject LastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Road")
        {
            GameObject Duplicate = Instantiate(collision.transform.parent.gameObject, LastSpawn.transform.position + new Vector3(0.0f, 0.0f, 12.0f) , Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Duplicate.name = "RoadSegment";

            LastSpawn = Duplicate;

            Destroy(collision.transform.parent.gameObject, 0.0f);

            
        }
    }
}
