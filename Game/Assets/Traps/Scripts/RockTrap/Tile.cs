using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Scream Tile Type to TileChecker
            Debug.Log(gameObject.tag);
            GameObject.Find("Tiles").GetComponent<TileChecker>().walkPatern.Add(gameObject.tag);
        }
    }
}
