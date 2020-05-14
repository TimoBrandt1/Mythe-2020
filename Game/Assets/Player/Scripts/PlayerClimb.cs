using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerClimb : MonoBehaviour
{
    public GameObject ledge1;
    public GameObject ledge2;

    public delegate void OnPlayerClimb();
    public delegate void OnPlayerLoose();
    public event Action onPlayerClimb;
    public event Action onPlayerLoose;

    public Transform temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(ledge1.transform.position, transform.position);
        if (dist < 5 && Input.GetKey(KeyCode.Space))
        {
                transform.rotation = ledge1.transform.rotation;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, ledge1.transform.position.x - ledge1.transform.localScale.x/2, ledge1.transform.position.x + ledge1.transform.localScale.x/2),
                ledge1.transform.position.y,
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
        }
    }
}
