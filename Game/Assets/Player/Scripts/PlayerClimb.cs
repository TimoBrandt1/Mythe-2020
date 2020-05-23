using System.Collections;
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
    private bool grabStart = true;

    private Ledge[] allEnemies;
    public bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        FindSecondClosestEnemy();
        dist = Vector3.Distance(ledge1.transform.position, transform.position);
        if (dist < 5 && Input.GetKey(KeyCode.Space))
        {
                setFirstPos();
                transform.rotation = ledge1.transform.rotation;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, ledge1.transform.position.x - ledge1.transform.localScale.x/2, ledge1.transform.position.x + ledge1.transform.localScale.x/2),
                ledge1.transform.position.y - 1f,
                Mathf.Clamp(transform.position.z, ledge1.transform.position.z - ledge1.transform.localScale.x / 2, ledge1.transform.position.z + ledge1.transform.localScale.x / 2));

                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += transform.right * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= transform.right * Time.deltaTime;
                }

            onPlayerClimb();
            GetComponent<playerMove>().enabled = false;
            GetComponent<ThirdPersonCharacterControl>().enabled = false;
        }
        else
        {
            GetComponent<playerMove>().enabled = true;
            GetComponent<ThirdPersonCharacterControl>().enabled = true;
            onPlayerLoose();
            grabStart = true;
        }
    }

    void FindClosestEnemy()
    {
        
        float distanceToClosestEnemy = Mathf.Infinity;
        Ledge closestEnemy = null;
        allEnemies = GameObject.FindObjectsOfType<Ledge>();

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

            if (distanceToEnemy > 1f && distanceToEnemy < 12f && Input.GetKey(KeyCode.Tab) && jumped == false)
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
        if (grabStart)
        {
            Vector3 closestPoint = ledge1.GetComponent<BoxCollider>().ClosestPointOnBounds(this.transform.position);
            transform.position = closestPoint;
            //transform.position = new Vector3(ledge1.transform.position.x, ledge1.transform.position.y, ledge1.transform.position.z);
            grabStart = false;
        }
    }

    IEnumerator jumpTimer()
    {
        jumped = true;
        yield return new WaitForSeconds(0.5f);
        jumped = false;
    }
}
