using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    private List<string> startPatern = new List<string>();
    public List<string> walkPatern = new List<string>();

    

    private void Start()
    {
        startPatern.Add("Cow");
        startPatern.Add("Pig");
        startPatern.Add("Sheep");
    }

    private void Update()
    {
        CheckWalkPaternSize();
    }

    private void CheckLists()
    {

        if (ListEquals(walkPatern, startPatern))
        {
            Debug.Log("List 1 is the same as list 2");
            
        }
        else
        {
            Debug.Log("List 1 does not equal list 2");
            GameObject.Find("SpawnPoints").GetComponent<RockSpawning>().TrapTriggerd();
        }
    }

    private void CheckWalkPaternSize()
    {
        if (walkPatern.Count == 1)
        {
            CheckLists();
        }
        if (walkPatern.Count == 3)
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
