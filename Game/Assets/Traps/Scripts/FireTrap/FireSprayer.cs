using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprayer : MonoBehaviour
{
    [SerializeField] private GameObject[] row;
    [SerializeField] private Transform player;
    [SerializeField] private float activationRange;
    [SerializeField] private bool singleFlame = false;

    private GameObject StartPoint;
    private bool play = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        activationRange = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (play == false && singleFlame == false && distanceToPlayer < activationRange)
        {
            play = true;
            StartCoroutine(TimerMultiFlame());
        }
        if (play == false && singleFlame == true && distanceToPlayer < activationRange)
        {
           play = true;
           StartCoroutine(TimerSingleFlame());
        }
    }

    private IEnumerator TimerMultiFlame()
    {
        foreach (GameObject child in row)
        {
            child.GetComponentInChildren<ParticleSystem>().Play();
        }
        yield return new WaitForSeconds(3);
        foreach (GameObject fire in row)
        {
            fire.GetComponentInChildren<ParticleSystem>().Stop();
        }
        yield return new WaitForSeconds(3);
        play = false;

    }

    private IEnumerator TimerSingleFlame()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(Random.Range(1, 10));

        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        yield return new WaitForSeconds(Random.Range(1, 10));
        play = false;
    }
}
