using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 temp;
    private float destroyScale = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(50);
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
        if (transform.localScale == new Vector3(destroyScale, destroyScale, destroyScale))
        {
            Destroy(gameObject);
        }
    }
}
