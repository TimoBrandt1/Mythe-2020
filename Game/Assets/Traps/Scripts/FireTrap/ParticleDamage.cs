using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("TakeDamage", 100);
        }
    }
}
