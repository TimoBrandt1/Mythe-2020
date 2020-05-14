using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabTiles;
    [SerializeField] private int gridX;
    [SerializeField] private int gridZ;
    [SerializeField] private float gridSpacingOffset = 1f;
    private Vector3 spawnPos;
    void Start()
    {
        spawnPos = transform.position;
        SpawnTiles();
    }

    private void SpawnTiles()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPos;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }
    private void PickAndSpawn(Vector3 postionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, prefabTiles.Length);
        GameObject clone = Instantiate(prefabTiles[randomIndex], postionToSpawn, rotationToSpawn);
        clone.transform.SetParent(gameObject.transform);
    }
}
