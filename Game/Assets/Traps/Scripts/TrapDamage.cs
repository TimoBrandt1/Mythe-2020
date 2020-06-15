using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private int trapDamage;
    private string playerTag = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(trapDamage);
        }
    }
}
