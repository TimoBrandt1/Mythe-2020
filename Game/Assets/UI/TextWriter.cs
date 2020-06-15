using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingel> textWriterSingelList;

    private void Awake()
    {
        instance = this;
        textWriterSingelList = new List<TextWriterSingel>();
    }
    public static TextWriterSingel AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }
    private TextWriterSingel AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingel textWriterSingel = new TextWriterSingel(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingelList.Add(textWriterSingel);
        return textWriterSingel;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }
    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textWriterSingelList.Count; i++)
        {
            if (textWriterSingelList[i].GetUIText() == uiText)
            {
                textWriterSingelList.RemoveAt(i);
                i--;
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < textWriterSingelList.Count; i++)
        {
            bool destroyInstance = textWriterSingelList[i].Update();
            if (destroyInstance)
            {
                textWriterSingelList.RemoveAt(i);
                i--;
            }


        }
    }

    public class TextWriterSingel
    {
        private Text uiText;
        private string textToWrite;
        private int characterIntdex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextWriterSingel(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIntdex = 0;
        }
        public bool Update()
        {
            timer -= Time.deltaTime;

            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIntdex++;
                string text = textToWrite.Substring(0, characterIntdex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIntdex) + "</color>";
                }
                uiText.text = text;

                if (characterIntdex >= textToWrite.Length)
                {
                    if (onComplete != null)
                    {
                        onComplete();
                    }
                    return true;
                }
            }
            return false;
        }
        public Text GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIntdex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            uiText.text = textToWrite;
            characterIntdex = textToWrite.Length;
            if (onComplete != null)
            {
                onComplete();
            }
            TextWriter.RemoveWriter_Static(uiText);
        }
    }


}
