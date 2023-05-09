using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    private void Start() {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
    }

    private void OnTriggerExit (Collider other)
    {
        Debug.Log("EXIT");
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // this will destroy the last 2 tiles behind the player
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
