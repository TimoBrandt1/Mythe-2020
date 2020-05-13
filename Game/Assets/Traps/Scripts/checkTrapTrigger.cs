using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrapTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "deathTile")
        {
            GameObject.Find("SpawnPoints").GetComponent<RockShooting>().StartCoroutine(SpawnRocks());
        }
    }
}
