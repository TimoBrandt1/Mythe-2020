using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    [SerializeField] int damage = 5;
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("TakeDamage", damage);
        }
    }
}
