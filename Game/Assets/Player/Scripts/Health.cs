﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }
    public void TakeDamage(int dmgNumber)
    {
        health -= dmgNumber;
        Debug.Log("You took damage!");
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            //Animatie dood
            //Tijdelijk reload de scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
