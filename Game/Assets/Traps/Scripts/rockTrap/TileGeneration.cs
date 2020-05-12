using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabTiles;
    enum Tiles
    {
        COW,
        PIG,
        SHEEP,
        DEATH
    }
    // Start is called before the first frame update
    void Start()
    {
        int[,] intMap;
        intMap = new int[,]{
            {0, 0, 0, 0},
            {1, 1, 1, 1 }
        };
        for (int i = 0; i < intMap.Length; i++)
        {
            for (int j = 0; j < intMap.Length; j++)
            {
                GameObject aTile = Instantiate(prefabTiles[intMap[i, j]]);
                aTile.transform.position = new Vector3(
                    (aTile.GetComponent<Renderer>().bounds.size.x / 2) * i,
                    0,
                    (aTile.GetComponent<Renderer>().bounds.size.z / 2) * j
                    );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
