using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShooting : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float Timer = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRocks());
    }

    IEnumerator SpawnRocks()
    {
        Instantiate(rock, spawnPoints[0]);
        Instantiate(rock, spawnPoints[2]);
        yield return new WaitForSeconds(Timer);
        Instantiate(rock, spawnPoints[1]);
        Instantiate(rock, spawnPoints[3]);
        yield return new WaitForSeconds(Timer);
        StartCoroutine(SpawnRocks());
    }
}
