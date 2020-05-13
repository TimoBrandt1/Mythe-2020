using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float speed;
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        WallMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CrushWall")
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
        }
    }
    private void WallMove()
    {
        while (transform.position.x != destination.position.x -5)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed);
        }
    }
}
