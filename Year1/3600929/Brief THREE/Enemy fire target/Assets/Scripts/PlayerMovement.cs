using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed; // Playerspeed variable to change players speed in the inspector

    CharacterController characterController; // character controller cache variable which takes the character controller 

    public float X; // variables that will be set in start
    public float Z; 
    bool FunctionIsCalled = false; // bool function for when a function is being called 
    public bool ConstantDirection = false; // bool to check if the player is going in one constant direction

    void Start()
    {
        float X = Input.GetAxis("Horizontal"); // X variable holds the axis of the horizontal (x axis)
        float Z = Input.GetAxis("Vertical"); // Y variable holds the axis of the Vertical (y axis)
        characterController = GetComponent<CharacterController>(); // on start, character controller variable take the component
    }

    void Update()
    {
         FunctionIsCalled = false; // bool is always set to false 
         ConstantDirection = false;
         X = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime; // horizontal is multiplied by the time.deltatime and player speed for frame fitting movement
         Z = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
         characterController.Move(new Vector3(X, 0, Z)); // character controller will move at new vector3 posistions of the x axis by the X variable and 0 at the Y and Z at the z axis
         FowardRightOrLeft(); // called at fixed updates for the physics (methods)
         BackwardRightOrLeft();
         ConstantFowardBackwards();
         ConstantRightLeft();
    }

    public void FowardRightOrLeft() 
    {
        if (Z > 0 && X > 0) // checks if the Z variable is greater than 0 and X is greater than 0
        {
            Debug.Log("Foward Right"); 
            FunctionIsCalled = true; // the bool variable is set to true
        }

        else if (Z > 0 && X < 0) // or if Z is greater than 0 but X is less than 0
        {
            Debug.Log("Foward Left");
            FunctionIsCalled = true; // bool variable is set to true
        }
    }

    public void BackwardRightOrLeft() 
    {
        if (Z < 0 && X > 0) 
        {
            Debug.Log("Backward Right");
            FunctionIsCalled = true;
        }

        else if (Z < 0 && X < 0) 
        {
            Debug.Log("Backward left");
            FunctionIsCalled = true;
        }
    }

    public void ConstantFowardBackwards() 
    {
        if (Z > 0 &&  X <= 0 && !FunctionIsCalled) 
        {
            Debug.Log("Only going straight");
            ConstantDirection = true; // bool variable is set to true
        }
        
        else if (Z < 0 && X <= 0 && !FunctionIsCalled) 
        {
            Debug.Log("Only going Backwards");
            ConstantDirection = true;
        }
    }

    public void ConstantRightLeft() 
    {
        if (X > 0 && Z <= 0 && !FunctionIsCalled) 
        {
            Debug.Log("Going Right");
            ConstantDirection = true;
        }

        else if (X < 0 && Z <= 0 && !FunctionIsCalled) 
        {
            Debug.Log("Going Left");
            ConstantDirection = true; 
        }
    }
}
