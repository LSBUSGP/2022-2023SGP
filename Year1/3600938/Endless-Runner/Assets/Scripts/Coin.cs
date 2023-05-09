using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.GetComponent<Obstacle>()!= null)
        {
            return;
        }
        // check that the object we collided with is the player
        if (other.gameObject.name != "player"){return;}
        
        // Add to the player's score
         Debug.Log("Something happen");
        GameManager.inst.IncrementScore();

        // Destroy the coin object
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
