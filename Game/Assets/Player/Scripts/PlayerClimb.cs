﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerClimb : MonoBehaviour
{
    public GameObject ledge1;

    public delegate void OnPlayerClimb();
    public delegate void OnPlayerLoose();
    public event Action onPlayerClimb;
    public event Action onPlayerLoose;
    private float dist;
    public bool grabStart = false;

    public bool jumped = false;

    // Update is called once per frame
    void Update()
    {
        if (grabStart == false)
        {
            FindClosestEnemy();
        }

        dist = Vector3.Distance(ledge1.transform.position, transform.position);
        if (dist < 5 && Input.GetKey(KeyCode.Space))
        {
            setFirstPos();
            grabStart = true;
            onPlayerClimb();
            GetComponent<playerMove>().enabled = false;
            GetComponent<ThirdPersonCharacterControl>().enabled = false;
        }
        else
        {
            GetComponent<playerMove>().enabled = true;
            GetComponent<ThirdPersonCharacterControl>().enabled = true;
            onPlayerLoose();
            grabStart = false;
        }

        if (grabStart == true)
        {
            FindSecondClosestEnemy();

            transform.rotation = ledge1.transform.rotation;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, ledge1.transform.position.x - ledge1.transform.localScale.x / 2, ledge1.transform.position.x + ledge1.transform.localScale.x / 2),
            ledge1.transform.position.y - 1f,
            Mathf.Clamp(transform.position.z, ledge1.transform.position.z - ledge1.transform.localScale.x / 2, ledge1.transform.position.z + ledge1.transform.localScale.x / 2));

            if (Input.GetKey(KeyCode.D)) { transform.position += transform.right * Time.deltaTime; }

            if (Input.GetKey(KeyCode.A)) { transform.position -= transform.right * Time.deltaTime; }

            if (Input.GetKey(KeyCode.W)) { }

            if (Input.GetKey(KeyCode.S)) { }

        }
    }

    void FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;
        Ledge closestEnemy = null;
        Ledge[] allEnemies = GameObject.FindObjectsOfType<Ledge>();

        foreach (Ledge currentEnemy in allEnemies)
        {
            Vector3 closestPoint = currentEnemy.GetComponent<BoxCollider>().ClosestPointOnBounds(this.transform.position);
            Debug.DrawLine(this.transform.position, closestPoint);
            float distanceToEnemy = (closestPoint - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy && jumped == false)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ledge1 = currentEnemy.gameObject;
            }
        }
    }

    void FindSecondClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Ledge closestEnemy = null;
        Ledge[] allEnemies2 = GameObject.FindObjectsOfType<Ledge>();

        foreach (Ledge currentEnemy in allEnemies2)
        {
            Vector3 closestPoint = currentEnemy.GetComponent<BoxCollider>().ClosestPointOnBounds(this.transform.position);
            Debug.DrawLine(this.transform.position, closestPoint);
            float distanceToEnemy = (closestPoint - this.transform.position).sqrMagnitude;

            if (distanceToEnemy > 1f && distanceToEnemy < 12f && Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y == ledge1.transform.position.y && currentEnemy.gameObject.transform.position.z > ledge1.transform.position.z || distanceToEnemy > 1f && distanceToEnemy < 12f && Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y == ledge1.transform.position.y && currentEnemy.gameObject.transform.position.x > ledge1.transform.position.x)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ledge1 = currentEnemy.gameObject;
                StartCoroutine(jumpTimer());
            }

            if (distanceToEnemy > 1f && distanceToEnemy < 12f && Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y == ledge1.transform.position.y && currentEnemy.gameObject.transform.position.z < ledge1.transform.position.z || distanceToEnemy > 1f && distanceToEnemy < 12f && Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y == ledge1.transform.position.y && currentEnemy.gameObject.transform.position.x < ledge1.transform.position.x)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ledge1 = currentEnemy.gameObject;
                StartCoroutine(jumpTimer());
            }

            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y > ledge1.transform.position.y && jumped == false && distanceToEnemy > 1f && distanceToEnemy < 12f)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ledge1 = currentEnemy.gameObject;
                StartCoroutine(jumpTimer());
            }

            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && currentEnemy.gameObject.transform.position.y < ledge1.transform.position.y && jumped == false && distanceToEnemy < 12f)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                ledge1 = currentEnemy.gameObject;
                StartCoroutine(jumpTimer());
            }
        }
    }

    public void setFirstPos()
    {
        if (grabStart == false && Input.GetKey(KeyCode.Space))
        {
            Vector3 closestPoint = ledge1.GetComponent<BoxCollider>().ClosestPointOnBounds(this.transform.position);
            transform.position = closestPoint;
            //transform.position = new Vector3(ledge1.transform.position.x, ledge1.transform.position.y, ledge1.transform.position.z);
            grabStart = true;
        }
    }

    IEnumerator jumpTimer()
    {
        jumped = true;
        yield return new WaitForSeconds(1f);
        jumped = false;
    }
}