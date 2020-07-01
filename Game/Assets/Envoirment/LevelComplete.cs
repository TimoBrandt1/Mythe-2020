using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public event EventHandler OnEventEnter;
    [SerializeField] private GameObject _Backpack;
    [SerializeField] private Inventory _BackpackSlots;
    [SerializeField] private float _UseDistance = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isEnd = true;
    

    private void Start()
    {
        _BackpackSlots = _Backpack.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(_Backpack.transform.position, transform.position);
        if (dist < _UseDistance && Input.GetKey(KeyCode.E) && _BackpackSlots.full == true)
        {
            if (isEnd)
            {
                animator.SetTrigger("FadeOutLevelComplete");
            }
            if(isEnd == false)
            {
                OnEventEnter?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
