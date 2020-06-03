using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    Vector3 temp;
    //private float destroyScale = 0.3f;
    private bool disabled = false;
    // Update is called once per frame

    private void OnEnable()
    {
        speed = 20;
        Invoke("Disable", 0.6f);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RockTrap")
        {
            speed = 0;   
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
