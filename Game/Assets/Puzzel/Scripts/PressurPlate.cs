using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurPlate : MonoBehaviour
{
    [SerializeField] private AudioSource myAudio;
    private Renderer render;
    private float moveInt;
    private Color m_oldColor;

    

    private void Start()
    {
        myAudio = this.GetComponent<AudioSource>();
        render = GetComponent<Renderer>();
        m_oldColor = render.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
            myAudio.Play();
            Debug.Log(other.gameObject.name);
            Debug.Log("Naar beneden");
            moveInt = -0.01f;
            StartCoroutine(MovePressurplate());
    }
    private void OnTriggerExit(Collider other)
    {
        myAudio.Play();
        Debug.Log("Naar Boven");
            moveInt = 0.01f;
            StartCoroutine(MovePressurplate());
    }

    IEnumerator MovePressurplate()
    {

        for (int i = 0; i < 6; i++)
        {
            this.transform.position = this.transform.position += new Vector3(0f, moveInt, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
