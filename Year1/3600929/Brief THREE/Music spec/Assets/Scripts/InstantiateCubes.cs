using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{

    public GameObject SampleCubePrefabs; // lets me use the prefabed object to display the sample frequencies

    public float CicrleNumber = -0.703125f; // variable for the distance of how much a cube should have between eachother to create said circle
    public float MaxScale;

    GameObject[] SampleCubes = new GameObject[512]; // an array of gameobjects that will hold 512 gameobojects 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            FrequencyCubeCreator(i);
        }
    }

    void FrequencyCubeCreator(int i)
    {
        GameObject CloneCubes = (GameObject)Instantiate(SampleCubePrefabs); // gameobject temp variable will instanitaite the prefabs as long as I is less than 512
        CloneCubes.transform.position = this.transform.position; // this makes the cubes sit in the centre 
        CloneCubes.transform.parent = this.transform; // makes it a child of the class its running on 
        CloneCubes.name = "FrequencyCube" + i; // changes the names of the instances
        this.transform.eulerAngles = new Vector3(0, CicrleNumber * i, 0); // the eularangles function is used to create the circle effect for the instantiated prefabs fore each frequency 
        CloneCubes.transform.position = Vector3.forward * 100; // gives the cubes a distance between them
        SampleCubes[i] = CloneCubes; // gives the cubes the correct pos from the array
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++) // null check 
        {
            if (SampleCubes[i] != null) 
            {
                SampleCubes[i].transform.localScale = new Vector3(10,(AudioData.Samples[i] * MaxScale) +2, 10);
            }
        }    
    }
}
