using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    float Delay = 3.5f; // float variable 
 
    // Start is called before the first frame update
    void Start()
    {

     
    }
    // Update is called once per frame
    void Update()
    {
        DestroyMethod(); //  method called after every update 
    }

    void DestroyMethod() // new method created 
    {
        if (transform.position.z < Camera.main.transform.position.z) // checks whether the position of the cameras z axis is greater than the gameobjects z axis  
        {
            Destroy(gameObject, Delay); // destroys the gameobject whilst also adding a delay to when it should be removed using the variable declared above
            enabled = false; // enabled = false will stop the function from being called over and over 
        }
    }
}
