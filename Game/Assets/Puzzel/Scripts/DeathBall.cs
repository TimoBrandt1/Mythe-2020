using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour
{
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private bool canMove = false;
    private string playerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger;
    }
    [SerializeField] private float speed = 20;
    Vector3 temp;
    //private float destroyScale = 0.3f;

    // Update is called once per frame
    private void InputEventTrigger(object sender, System.EventArgs e)
    {
        canMove = true;
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        canMove = false;
    }
    private void OnEnable()
    {
        speed = 20;
    }

    void Update()
    {
        if (canMove == true)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(50);
        }
        if (collision.gameObject.tag == "RockTrap")
        {
            speed = 0;
        }
    }
}
