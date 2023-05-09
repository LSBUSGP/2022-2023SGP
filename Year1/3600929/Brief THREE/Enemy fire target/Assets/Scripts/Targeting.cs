using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] Transform Weapon; // variable for weapon object
    [SerializeField] Transform Target; // variable which will hold what the object will target

    PlayerMovement MovementScript;
    ParticleSystem PS;

    Transform RelativeTo;


    // Start is called before the first frame update
  
    void Start()
    {
        //PS = GetComponent<ParticleSystem>(); // PS variable contains the partcile system components within it
        MovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // finds the tage player and takes the script from the game object
        PS = gameObject.GetComponentInChildren<ParticleSystem>(); // PS variable contains the partcile system components within it
        Target = FindAnyObjectByType<PlayerMovement>().transform; // target variable finds an object with the script and its transform directions
    }

    // Update is called once per frame
    void Update()
    {
        AimAtPlayer(); // method called every time
        AimConstantSpeedDetected();
    }

    void AimAtPlayer() // declared method for when it should be called
    {
        Weapon.LookAt(Target); // makes the veapon variable specifically the object look at the target variable
    }

    void AimConstantSpeedDetected() 
    {
        if (MovementScript.ConstantDirection == true)
        {
            var MainModule = PS.main;
            MainModule.simulationSpace = ParticleSystemSimulationSpace.Local;
            MainModule.customSimulationSpace = RelativeTo;
            Debug.Log("Its working");
        }

        else 
        {
            var MainModule = PS.main;
            MainModule.simulationSpace = ParticleSystemSimulationSpace.World;
        }
    }
}
