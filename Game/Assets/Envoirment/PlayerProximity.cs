using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximity : MonoBehaviour
{
    [SerializeField] private int _lightRange = 3000;
    private GameObject[] _objects;
    private float _offset = 0.02f;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _lightRange);

        foreach (Collider light in hits)
        {
            float distanceToLight = Vector3.Distance(transform.position, light.transform.position);
            if (distanceToLight >= (_lightRange * _offset))
            {
                if (light.gameObject.GetComponentInChildren<MeshRenderer>() != null)
                {
                    light.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                }
            }
            if (distanceToLight < (_lightRange * _offset))
            {
                if (light.gameObject.GetComponentInChildren<MeshRenderer>() != null)
                {
                    light.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lightRange);
    }
}