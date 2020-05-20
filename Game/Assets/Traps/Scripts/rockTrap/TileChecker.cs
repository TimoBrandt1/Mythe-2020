using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    //Get first 3 tiles that have been walked on and make it the partern
    private List<string> startPatern = new List<string>();
    public List<string> walkPatern = new List<string>();

    private void Start()
    {
        startPatern.Add("Cow");
        startPatern.Add("Pig");
        startPatern.Add("Sheep");
        startPatern.Clear();
    }

    private void Update()
    {
        CheckWalkPaternSize();
    }

    private void ComparePaterns()
    {
        if (true)
        {

        }
        else
        {

        }
            GameObject.Find("SpawnPoints").GetComponent<RockSpawning>().TrapTriggerd();
    }
    private void CheckWalkPaternSize()
    {
        if (walkPatern.Count == 3)
        {
            ComparePaterns();
            walkPatern.Clear();
        }
        if (walkPatern.Count > 3)
        {
            walkPatern.Clear();
        }
    }
}
