using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 temp;
    float t = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime *speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
        }
        else
        {
            speed = 0;
            Shrink();
        }
    }

    private void Shrink()
    {
        Debug.Log(transform.localScale);
        temp = transform.localScale;

        temp.x -= 100 * Time.deltaTime;
        temp.y -= 100 * Time.deltaTime;
        temp.z -= 100 * Time.deltaTime;

        transform.localScale = temp;
        if (transform.localScale == new Vector3(0f, 0f, 0f))
        {
            Destroy(gameObject);
        }
    }
}
