using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawning : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float Timer = 0.001f;
    private bool canBeTriggerd = true;

    public void TrapTriggerd()
    {
        if (canBeTriggerd)
        {
            StartCoroutine(SpawnRocks());
            canBeTriggerd = false;
        }
    }

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
