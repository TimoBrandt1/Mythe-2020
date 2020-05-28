using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private GameObject textImage;
    private Text messageText;
    private TextWriter.TextWriterSingel textWriterSingel;
    private AudioSource talkingAudioSource;
    private int currentMessageIndex=0;
    public void Awake()
    {
        string[] messageArray = File.ReadAllLines(Application.dataPath + "/UI/Text.json");
        //textImage = GameObject.Find("textImage");
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
        if (textWriterSingel != null && textWriterSingel.IsActive())
        {
            textWriterSingel.WriteAllAndDestroy();
        }
        else
        {
            
            /*string[] messageArray = new string[] {
            "hello brave explorer you are now in the tempel of doom",
            "your task is to get the holy grale and make it out alive",
            "Beware if what lies ahead it might be dangerous",
            "White = good, Black = Death",
            "Hold space to climbe a lege",
            "Dont get Crushed"*/
        };
            if (currentMessageIndex > messageArray.Length -1) { currentMessageIndex = 0; }
            talkingAudioSource.Play();
            string message = messageArray[currentMessageIndex];
            StartTalkingSound();
            textWriterSingel = TextWriter.AddWriter_Static(messageText, message, 0.05f, true, true, StopTalkingSound);
            currentMessageIndex++;
    }

    private void StartTalkingSound()
    {
        textImage.SetActive(true);
        talkingAudioSource.Play();
    }

    private void StopTalkingSound()
    {
        StartCoroutine(ResetText());
        talkingAudioSource.Stop();
    }

    private IEnumerator ResetText()
    {
        
        yield return new WaitForSeconds(1);
        messageText.text = null;
        textImage.SetActive(false);
    }
    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, "hallo ik ben jordi en je bent nu in de tempel of doom. Voltooi het level en ontsnap uit de tempel", 0.05f, true);
    }
}
