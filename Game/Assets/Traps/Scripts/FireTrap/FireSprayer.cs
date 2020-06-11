using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprayer : MonoBehaviour
{
    [SerializeField] private GameObject[] row;
    [SerializeField] private bool singleFlame = false;

    private GameObject StartPoint;
    private bool play = false;

    // Update is called once per frame
    void Update()
    {
        if (play == false && singleFlame == false)
        {
            play = true;
            StartCoroutine(TimerMultiFlame());
        }
        if (play == false && singleFlame == true)
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
