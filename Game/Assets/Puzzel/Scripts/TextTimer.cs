using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private float remTime;
    [SerializeField] private Text timerText;
    private string stdTime;
    private bool counting = true;
    private string displaytext;
    private Color displayColor;
    private float ResetTimer = 2;

    private void Start()
    {
        timerText = GetComponent<Text>();
        timerText.color = Color.cyan;
    }

    private void Update()
    {
        if (timer._GetTimer() > 0)
        {
            stdTime = ((int)timer._GetTimer()+1).ToString();
            timerText.text = stdTime;
        }
    }

    public void StartTimer(float aValue,string aText, Color aColor)
    {
        displayColor = aColor;
        displaytext = aText;
        timer.SetTimer(aValue, () => TimerComplete());  
    }

    public void SetText(string aText, float aResetTimer)
    {
        timerText.text = aText;
        ResetTimer = aResetTimer;
        timer.SetTimer(0, () => StartCoroutine(resetText()));
    }

    public void TimerComplete()
    {
        timerText.color = displayColor;
        timerText.fontSize = 70;
        timerText.text = displaytext;
        Debug.Log("timer complete");
        StartCoroutine(resetText());
    }

    IEnumerator resetText()
    {
        timerText.color = Color.cyan;
        yield return new WaitForSeconds(ResetTimer);
        timerText.text = null;

    }
    
}
