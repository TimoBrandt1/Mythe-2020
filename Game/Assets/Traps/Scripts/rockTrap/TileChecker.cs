using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    private List<string> startPatern = new List<string>(new string[] { "Cow", "Pig", "Sheep" });
    public List<string> walkPatern = new List<string>();

    private void Update()
    {
        CheckWalkPaternSize();
    }

    private void CheckLists()
    {

        if (ListEquals(walkPatern, startPatern))
        {
            //Lists are the same nothing will hapen
        }
        else
        {
            //List are not the same you the trap will be triggerd
            GameObject.Find("SpawnPoints").GetComponent<RockSpawning>().TrapTriggerd();
        }
    }

    private void CheckWalkPaternSize()
    {
        if (walkPatern.Count == 1)
        {
            CheckLists();
        }
        else if (walkPatern.Count == 3)
        {
            walkPatern.Clear();
        }
    }

    public static bool ListEquals<T>(IList<T> list1, IList<T> list2)
    {
        for (int i = 0; i < list1.Count; i++)
        {
            if (!list1[i].Equals(list2[i]))
            {
                return false;
            }
        }     
        return true;
    }
}
