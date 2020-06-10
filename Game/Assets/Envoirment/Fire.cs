using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject InputEventTriggerObject;
    public GameObject OutputEventTriggerObject;
    private ParticleSystem myParticle;
    private AudioSource myAudio;
    private void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        myParticle = gameObject.GetComponent<ParticleSystem>();
        EventTrigger inputEventTrigger = InputEventTriggerObject.GetComponent<EventTrigger>();
        inputEventTrigger.OnEventEnter += InputEventTrigger;

        EventTrigger outputEventTrigger = OutputEventTriggerObject.GetComponent<EventTrigger>();
        outputEventTrigger.OnEventEnter += OutputEventTrigger;
    }
    private void InputEventTrigger(object sender, System.EventArgs e)
    {
        myAudio.Play();
        myParticle.Play();
    }
    private void OutputEventTrigger(object sender, System.EventArgs e)
    {
        myAudio.Stop();
        myParticle.Stop();
    }
}
