using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawning : MonoBehaviour
{
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
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) yield return null;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            obj.transform.position = spawnPoints[i].position;
            obj.transform.rotation = spawnPoints[i].rotation;
            obj.SetActive(true);
            if (i == 4 || i == 8)
            {
                yield return new WaitForSeconds(Timer);
            }
        }
        StartCoroutine(SpawnRocks());
    }
}
