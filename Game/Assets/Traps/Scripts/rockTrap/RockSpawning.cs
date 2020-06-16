using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawning : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float Timer;
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
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject obj = ObjectPooler.current.GetPooledObject();
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            obj.transform.position = spawnPoints[i].position;
            obj.transform.rotation = spawnPoints[i].rotation;
            obj.SetActive(true);

            if (i == spawnPoints.Length - 1)
            {
                yield return new WaitForSeconds(Timer);
                StartCoroutine(SpawnRocks());
            }
        }
    }
}
