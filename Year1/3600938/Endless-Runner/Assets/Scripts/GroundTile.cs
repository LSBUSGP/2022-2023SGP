using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefabs;
    [SerializeField] GameObject tallObstaclePrefabs;
    [SerializeField] float tallobstacleChance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other) 
    {
       groundSpawner.SpawnTile(true); 
       Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnObstacle () 
    {
        // Choose which obstacle to spawn
        GameObject ObstacleToSpawn = obstaclePrefabs;
        float random = Random.Range(0f, 1f);
        if (random < tallobstacleChance)
        {
            ObstacleToSpawn = tallObstaclePrefabs;
            Debug.Log("Something happen");
        }


        // Choose a random point to spaawn the obstacle
         int obstacleSpawnIndex = Random.Range(2,5);
         Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        // Spawn the obstacle at the position
        Instantiate(ObstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins ()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
           GameObject temp = Instantiate(coinPrefab, transform);
           temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider) 
    {
       Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
      }

      point.y = 1;
      return point;
    }
}
