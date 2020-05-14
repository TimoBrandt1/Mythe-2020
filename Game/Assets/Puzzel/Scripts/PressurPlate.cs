using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurPlate : MonoBehaviour
{
    private Renderer render;
    private float moveInt;
    private Color m_oldColor;
    

    private void Start()
    {
        render = GetComponent<Renderer>();
        m_oldColor = render.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log(other.gameObject.name);
            Debug.Log("Naar beneden");
            moveInt = -0.01f;
            StartCoroutine(MovePressurplate());
            render.material.color = Color.green;
    }
    private void OnTriggerExit(Collider other)
    {
            Debug.Log("Naar Boven");
            moveInt = 0.01f;
            StartCoroutine(MovePressurplate());
            this.render.material.color = m_oldColor;
    }

    IEnumerator MovePressurplate()
    {

        for (int i = 0; i < 3; i++)
        {
            this.transform.position = this.transform.position += new Vector3(0f, moveInt, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
