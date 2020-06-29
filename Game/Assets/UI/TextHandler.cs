using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private AudioSource talkingSound;
    [SerializeField] private GameObject textImage;
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

    public void StartWriter(string textToWrite, float timePerCharacter, float cleanText)
    {
        if (isPLaying == false)
        {
            StartCoroutine(WriteText(textToWrite, timePerCharacter, cleanText));
        }
        else
        {
            //textToSay.Add(new string[] { textToWrite});
        }
    }
    private IEnumerator WriteText(string textToWrite, float timePerCharacter, float cleanText)
    {
        talkingSound.pitch = talkingSound.pitch * (0.125f/timePerCharacter);
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
}
