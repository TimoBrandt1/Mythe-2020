using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    
    [SerializeField] private AudioSource talkingSound;
    [SerializeField] private GameObject textImage;
    [SerializeField] private Image Image;
    private Text messageText;
    private string currentText;
    private bool isPLaying = false;
    private string[] textToSay;

    // Update is called once per frame
    private void Start()
    {
        messageText = transform.Find("message").Find("Text").GetComponent<Text>();
    }
    private void Update()
    {
    }

    public void StartWriter(string textToWrite, float timePerCharacter, float cleanText, Sprite image)
    {
        if (isPLaying == false)
        {
            StartCoroutine(WriteText(textToWrite, timePerCharacter, cleanText, image));
        }
        else
        {
            //textToSay.Add(new string[] { textToWrite});
        }
    }
    public void StartWriterWithsound(string textToWrite, float timePerCharacter, float cleanText, AudioClip myclip, Sprite image)
    {
        if (isPLaying == false)
        {
            StartCoroutine(WriteTextWithSound(textToWrite, timePerCharacter, cleanText, myclip,image));
        }
        else
        {
            //textToSay.Add(new string[] { textToWrite});
        }
    }
    private IEnumerator WriteText(string textToWrite, float timePerCharacter, float cleanText, Sprite image)
    {
        //talkingSound.pitch = talkingSound.pitch * (0.125f/timePerCharacter);
        Image.sprite = image;
        isPLaying = true;
        textImage.SetActive(true);
        talkingSound.Play();
        for (int i = 0; i < textToWrite.Length+1; i++)
        {
            currentText = textToWrite.Substring(0, i);
            messageText.text = currentText;
            yield return new WaitForSeconds(timePerCharacter);
        }
        talkingSound.Stop();
        talkingSound.pitch = 1;
        yield return new WaitForSeconds(cleanText);
        messageText.text = "";
        textImage.SetActive(false);
        isPLaying = false;
    }
    private IEnumerator WriteTextWithSound(string textToWrite, float timePerCharacter, float cleanText, AudioClip myclip, Sprite image)
    {
        //talkingSound.pitch = talkingSound.pitch * (0.125f/timePerCharacter);
        Image.sprite = image;
        isPLaying = true;
        textImage.SetActive(true);
        talkingSound.clip = myclip;
        timePerCharacter = (myclip.length -1)/ textToWrite.Length;
        talkingSound.Play();
        for (int i = 0; i < textToWrite.Length + 1; i++)
        {
            currentText = textToWrite.Substring(0, i);
            messageText.text = currentText;
            yield return new WaitForSeconds(timePerCharacter);
        }
        yield return new WaitForSeconds(cleanText);
        messageText.text = "";
        textImage.SetActive(false);
        isPLaying = false;


    }
}
