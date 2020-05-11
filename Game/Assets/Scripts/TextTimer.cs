using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private float remTime;
    public Text timerText;
    private string stdTime;
    private bool counting = true;
    [SerializeField]private float waitingTime = 5f;


    private void Update()
    {
        if (timer._GetTimer() > 0)
        {
            stdTime = ((int)timer._GetTimer()+1).ToString();
            timerText.text = stdTime;
        }
    }

    public void StartTimer()
    {
        timer.SetTimer(waitingTime, () => TimerComplete());  
    }



    public void TimerComplete()
    {
        timerText.color = Color.red;
        timerText.fontSize = 70;
        timerText.text = "JE BENT GAYYYYYYYY";
        Debug.Log("timer complete");
    }
}
