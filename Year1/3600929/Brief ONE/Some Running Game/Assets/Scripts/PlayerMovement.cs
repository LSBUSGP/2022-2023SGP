using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float CharSpeed = 7f; // variable for speed

    bool TurnLeft; // variable for turning left
    bool TurnRight; // variable for turning right 

    private CharacterController TheCharacterController; // character controller variable
   

    // Start is called before the first frame update
    void Start()
    {
        TheCharacterController = GetComponent<CharacterController>(); // the variable now contains the components from CharacterController
    }

    // Update is called once per frame
    void Update()
    {
        TurnLeft = Input.GetKeyDown(KeyCode.A); // Turnleft variable will activate after the key a is pressed 
        TurnRight = Input.GetKeyDown(KeyCode.D); // Turnright variable is activated after the key d is pressed

        if (TurnLeft) // if key a is pressed
        {
            transform.Rotate(new Vector3(0f, -90f, 0f)); // rotate the player on the x axist by -90
        }
        else if (TurnRight) // else if they press the d button isntead 
        {
            transform.Rotate(new Vector3(0f, 90f, 0f)); // rotate the player 90 on the x axis
        }
        TheCharacterController.SimpleMove(new Vector3(0f, 0f, 0f)); // 
        TheCharacterController.Move(transform.forward * CharSpeed * Time.deltaTime); // the variable thecharactercontroller moves foward by multiplying itself by the charspeed variable and time.deltatime in order to fit the frames perfectly   
    }
}
