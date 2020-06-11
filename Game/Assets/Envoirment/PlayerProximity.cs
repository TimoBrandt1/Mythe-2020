using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximity : MonoBehaviour
{
    [SerializeField] private int lightRange = 30000;
    private GameObject[] objects;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, lightRange);

        foreach (Collider light in hits)
        {
                float distanceToLight = Vector3.Distance(transform.position, light.transform.position);
                if (distanceToLight >= (lightRange * 0.02))
                {
                if (light.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    light.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                }
                if (distanceToLight < (lightRange * 0.02))
                {
                if (light.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    light.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lightRange);
    }
}