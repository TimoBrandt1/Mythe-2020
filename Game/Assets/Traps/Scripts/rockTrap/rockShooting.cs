using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShooting : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float Timer = 0.001f;

    private IEnumerator SpawnRocks()
    {
        Instantiate(rock, spawnPoints[0]);
        Instantiate(rock, spawnPoints[2]);
        Instantiate(rock, spawnPoints[5]);
        Instantiate(rock, spawnPoints[7]);
        yield return new WaitForSeconds(Timer);
        Instantiate(rock, spawnPoints[1]);
        Instantiate(rock, spawnPoints[3]);
        Instantiate(rock, spawnPoints[4]);
        Instantiate(rock, spawnPoints[6]);
        yield return new WaitForSeconds(Timer);
        StartCoroutine(SpawnRocks());
    }
}
