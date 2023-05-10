using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 5;
    public float pushForce = 30;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.drag = 0;
            if (rigidbody.velocity.magnitude < speed)
                rigidbody.AddForce(new Vector3(0, 0, pushForce * Time.deltaTime), ForceMode.Impulse);
            //rigidbody.velocity = new Vector3(0, 0, speed);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.drag = 5;
        }
    }
}
