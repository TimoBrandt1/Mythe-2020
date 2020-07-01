using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HG : MonoBehaviour
{

    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    [SerializeField] private Rigidbody rb;
    [SerializeField] int waitingTime;
    [SerializeField] private Animator animator;


    private void Start()
    {
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger_OnSpacePressed;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger_OnSpacePressed;
    }
    private void InputEventTrigger_OnSpacePressed(object sender, System.EventArgs e)
    {
        StartCoroutine(DropHG());
    }
    private void OutputEventTrigger_OnSpacePressed(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator DropHG()
    {
        yield return new WaitForSeconds(waitingTime);
        rb.useGravity = true;
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
