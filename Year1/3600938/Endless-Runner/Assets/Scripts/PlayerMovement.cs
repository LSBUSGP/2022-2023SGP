using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    float distanceunit = 0;
    public Text distancemoved;

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate() 
    {
        if (!alive) return;

       Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
       Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
       rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("distance", 0, 1 / speed);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            jump();
        }

        if(transform.position.y < -5) {Die();}
    }

    public void Die () 
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void jump ()
    {
        // check whether we are currenty grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down,(height/ 2) + 0.1f, groundMask);

        // If we are, jump
        rb.AddForce(Vector3.up * jumpforce);
    }

    void distance()
    {
       
        distanceunit = distanceunit + 1;
        distancemoved.text = distanceunit.ToString();
        Debug.Log("Something happen");


    }
}
