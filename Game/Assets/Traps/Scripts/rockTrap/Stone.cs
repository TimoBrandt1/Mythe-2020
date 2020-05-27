using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    Vector3 temp;
    private float destroyScale = 0.3f;
    private string playerTag = "Player";
    // Update is called once per frame

    private void OnEnable()
    {
        if (speed == 0)
        {
            speed = 20;
        }
        Invoke("Disable", 1f);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(50);
        }
        else
        {
            speed = 0;
            //Shrink();
        }
    }

    //private void shrink()
    //{
    //    temp = transform.localscale;

    //    temp.x -= 100 * time.deltatime;
    //    temp.y -= 100 * time.deltatime;
    //    temp.z -= 100 * time.deltatime;

    //    transform.localscale = temp;
    //    if (transform.localscale == new vector3(destroyscale, destroyscale, destroyscale))
    //    {
    //        destroy(gameobject);
    //    }
    //}
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
