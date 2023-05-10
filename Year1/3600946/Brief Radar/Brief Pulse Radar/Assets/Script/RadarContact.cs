using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RadarContact : MonoBehaviour {
    public List<PulseRadar> contacts;
    public float radarRadius = 10;
    public GameObject radarEnemyPrefab;
    public Transform radarEnemyParent;
    private void Start()
    {
        foreach (var contact in contacts)
        {
            Instantiate(radarEnemyPrefab, radarEnemyParent);
        }
        }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, contacts[i].transform.position);
            Vector2 direction = contacts[i].transform.position - transform.position;
            if (distance >= 100 / radarRadius)
            {
                radarEnemyParent.GetChild(i).GetComponent<RectTransform>().anchoredPosition = direction.normalized * 100;
            }
            else
            {
                radarEnemyParent.GetChild(i).GetComponent<RectTransform>().anchoredPosition = direction * 100 / radarRadius;
            }
        }
       foreach (var contact in contacts)
        {


        }
    } 
} 