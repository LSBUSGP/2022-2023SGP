using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewPlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject PlatformToSpawn; // serializefield variables that will hold the obejects
    [SerializeField] GameObject ObjectReferencePoint; // variable for where the tile should start spawning

    [SerializeField] float GapsBetweenPlatforms = 3.5f; // float variable for the gaps between the platforms
    [SerializeField] float TimeOffset = 0.4f; // serialized variable for timeoffset of when tiles should spawn 
    [SerializeField] float RandomNumber = 0.7f; // random number to when a tile should spawn variable 
    float StartTime; // variable for starttime

    Vector3 PreviousTilePosition; // vector3 variable for the previous tile position
    Vector3 Direction = new Vector3 (0f, 0f, 1f); // z pos for the tiles placement variable 
    Vector3 MainDirection = new Vector3 (0f, 0f, 1f); // z pos variable
    Vector3 LeftorRightDirection = new Vector3 (1f, 0f, 0f); // for the turns in the platform game variable


    // Start is called before the first frame update
    void Start()
    {
        PreviousTilePosition = ObjectReferencePoint.transform.position; // variable previoustileposition will contain the objecttouse variable once seleccted in the unity inspector
        StartTime = Time.time;  // Startime variable will contain the time.time function, holding the time the game has been running for
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - StartTime > TimeOffset) // if the time the game is ran take away the startime is greater than timeoffset, a platform will be duplicated/ insantiated
        {
            if (Random.value < RandomNumber) // randomly assigns when a turn should be made in the game by whther the random value is lower than the randomnumber variable we chose 
            {
                Direction = MainDirection; // direction of the platform will spawn at the z axis 
            }
            else
            {
                Vector3 Cache = Direction; // temp variable holding the normal value the tiles will spawn at
                Direction = LeftorRightDirection; //the variable will convert into the turn tiles that face in the x axis ratherr tthan the z axis
                MainDirection = Direction; // variable maindirection turns into the direction variable and will continue to spawn platforms in that direction
                LeftorRightDirection = Cache; // the temp variable now holds the leftorrightdirection
            }

            Vector3 SpawnPlace = PreviousTilePosition + GapsBetweenPlatforms * Direction; // vector 3 temp variable which holds the value previoustile variable + gaps variable * by the direction the platform is going
            StartTime = Time.time; // decalre starttime variable to time.time aka as soon as it is ran 
            Instantiate(PlatformToSpawn, SpawnPlace, Quaternion.Euler(0f, 0f, 0f));
            PreviousTilePosition = SpawnPlace; // previous tile variable replaces whats inside the temp variable
        }
    } 
}
