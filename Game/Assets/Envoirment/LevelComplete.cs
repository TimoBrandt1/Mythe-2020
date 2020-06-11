using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject Backpack;
    [SerializeField] private Inventory BackpackSlots;
    [SerializeField] private float UseDistance = 1f;

    private void Start()
    {
        BackpackSlots = Backpack.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Backpack.transform.position, transform.position);
        if (dist < UseDistance && Input.GetKey(KeyCode.E) && BackpackSlots.full == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
