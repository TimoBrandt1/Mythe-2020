using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTrigger : PressurPlate
{
    [SerializeField] private bool canSetText;
    [SerializeField] private TextHandler textHandler;
    [SerializeField] private string[] texts;
    [SerializeField] private float[] timePerCharacter;
    [SerializeField] private Sprite[] images;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private float cleanTime;
    private bool nextText;
    private void Start()
    {
        canSetText = true;
        textHandler = GameObject.Find("TextHandeler").GetComponent<TextHandler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canSetText)
        {
            
            StartCoroutine(PassText());
            //Debug.Log("geef text door");
        }
    }
    private void OnTriggerExit(Collider other){ canSetText = false;}
    private IEnumerator PassText()
    {

        for (int i = 0; i < texts.Length;)
            {
                textHandler.StartWriterWithsound(texts[i], timePerCharacter[i], cleanTime,sounds[i], images[i]);
                //Debug.Log("gaat schrijven");
                yield return new WaitForSeconds((timePerCharacter[i]*texts[i].Length)+1+cleanTime);          
                i++;  
            }
        }
}
