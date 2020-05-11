using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurPlate : MonoBehaviour
{
    private Renderer render;
    [SerializeField] protected GameObject trigger;
    private float moveInt;
    private Color m_oldColor = Color.grey;
    bool canMove = true;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canMove == true)
        {
            moveInt = -0.01f;
            StartCoroutine(MovePressurplate());
            m_oldColor = render.material.color;
            render.material.color = Color.green;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (canMove == true)
        {
            moveInt = 0.01f;
            StartCoroutine(MovePressurplate());
            render.material.color = m_oldColor;
            canMove = false;
        }
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
