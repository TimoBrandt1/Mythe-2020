using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private float downMoveQuantity = -0.015f;
    private float upMoveQuantity = 0.015f;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TileMove(downMoveQuantity));
            Debug.Log(gameObject.tag);
            GameObject.Find("Tiles").GetComponent<TileChecker>().walkPatern.Add(gameObject.tag);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(TileMove(upMoveQuantity));
    }

    IEnumerator TileMove(float tileMoveFloat)
    {
        float waitTime = 0.1f;
        for (int i = 0; i < 3; i++)
        {
            this.transform.position = this.transform.position += new Vector3(0f, tileMoveFloat, 0f);
            yield return new WaitForSeconds(waitTime);
        }

    }
}
