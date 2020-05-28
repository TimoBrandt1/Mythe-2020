using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSphere : MonoBehaviour
{
    int i = 0;
    [SerializeField] private int lightRange = 3;
    public string lightTag = "light";
    private GameObject[] lights;
    [SerializeField] private float smooth = 1;
    [SerializeField] private float onIntencity = 2f;
    [SerializeField] private float offIntencity = 0f;

    private void Start()
    {
        InvokeRepeating("UpdateLight", 0f, 0.1f);
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, lightRange);

        foreach (Collider light in hits)
        {
            foreach (Transform child in light.transform.GetComponentInChildren<Transform>())
            {
                if (child.tag == "light")
                {
                    float distanceToLight = Vector3.Distance(transform.position, child.transform.position);
                    if (distanceToLight >= (lightRange * 0.75))
                    {
                        if (child.GetComponent<ParticleSystem>().isPlaying)
                        {
                            StartCoroutine(UpdateLight(child.GetComponent<Light>(), offIntencity,false));
                            smooth = 3;
                            child.GetComponent<ParticleSystem>().Stop();
                        }
                    }
                    if (distanceToLight < (lightRange * 0.75))
                    {
                        if (child.GetComponent<ParticleSystem>().isStopped)
                        {
                            StartCoroutine(UpdateLight(child.GetComponent<Light>(), onIntencity,true));
                            smooth = 1;
                            child.GetComponent<ParticleSystem>().Play();
                        }
                    }

                }
            }
        }


    }

    private IEnumerator UpdateLight(Light light, float targetIntencity,bool on)
    {
        while (light.intensity != targetIntencity)
        {
            if (on == true)
            {
                if (light.intensity >= (targetIntencity * 0.9))
                {
                    light.intensity = targetIntencity;
                }
            }
            else {
                if (light.intensity <= 0.1)
                {
                    light.intensity = 0;
                }
            }
            light.intensity = Mathf.Lerp(light.intensity, targetIntencity, Time.deltaTime * smooth);
            yield return new WaitForSeconds(0);
            
        }

    }

    private void OnDrawGizmosSelected()
    {
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, lightRange);
    }
}
