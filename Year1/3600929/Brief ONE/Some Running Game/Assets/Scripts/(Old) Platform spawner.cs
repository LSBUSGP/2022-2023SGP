using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] Transform PlatformDuplicate; // serialize field to access from unity, a transfrom variable called platform 
    Vector3 PlatformIncrementer; // A vector3 Variable called PlatfromIncrementer (vector 3s take 3 values (x,y,z))
    

    // Start is called before the first frame update
    void Start()
    {
        PlatformIncrementer.z = 19.2f; // starts at the 12th tile/platform
        StartCoroutine(PlatformSpawn()); // calls at the start of the progrram which will repeat the method since its a coroutine
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator PlatformSpawn() // IEnumerator is a method for coroutines that runs after a variable amount of time  
    {
        yield return new WaitForSeconds(1.5f); // setting the protocools of when the coroutine should start again
        Instantiate(PlatformDuplicate, PlatformIncrementer, PlatformDuplicate.rotation); // Instantiate will bring the object into the game and spawn the using the platforms objects, the 3 vector3 axis of the object and the objects rotation itself 
        PlatformIncrementer.z += 3.2f; // platformincrementer increments after 3 unity units in the z axis
        StartCoroutine(PlatformSpawn()); // the coroutine is called back here when closing the code, which will be referenced in the start posistion
    }
}
