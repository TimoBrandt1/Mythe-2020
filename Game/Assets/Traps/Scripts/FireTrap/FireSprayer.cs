using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprayer : MonoBehaviour
{
    [SerializeField] private GameObject[] _row;
    [SerializeField] private Transform _player;
    [SerializeField] private float _activationRange;
    [SerializeField] private bool _singleFlame = false;
    [SerializeField] private AudioSource _myAudio;

    private GameObject _StartPoint;
    private bool _play = false;

    private void Start()
    {
        _myAudio = gameObject.GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _activationRange = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (_play == false && _singleFlame == false && distanceToPlayer < _activationRange)
        {
            _play = true;
            StartCoroutine(TimerMultiFlame());
        }
        if (_play == false && _singleFlame == true && distanceToPlayer < _activationRange)
        {
           _play = true;
           StartCoroutine(TimerSingleFlame());
        }
    }

    private IEnumerator TimerMultiFlame()
    {
        foreach (GameObject child in _row)
        {
            child.GetComponentInChildren<ParticleSystem>().Play();
            _myAudio.Play();
        }
        yield return new WaitForSeconds(3);
        foreach (GameObject fire in _row)
        {
            fire.GetComponentInChildren<ParticleSystem>().Stop();
            _myAudio.Stop();
        }
        yield return new WaitForSeconds(3);
        _play = false;

    }

    private IEnumerator TimerSingleFlame()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        _myAudio.Play();
        yield return new WaitForSeconds(Random.Range(1, 10));

        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        _myAudio.Stop();
        yield return new WaitForSeconds(Random.Range(1, 10));
        _play = false;
    }
}
