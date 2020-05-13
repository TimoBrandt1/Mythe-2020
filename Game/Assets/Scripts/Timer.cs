using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Action timerCallback;
    private float timer = 0;

    public void SetTimer(float timer, Action timerCallback)
    {
        this.timer = timer;
        this.timerCallback = timerCallback;
    }

    private void Update()
    {
        if (timerCallback != null)
        {
            if (timer >= 0f)
            {
                timer -= Time.deltaTime;
                if (IsTimerComplete())
                {
                    timerCallback();
                    timerCallback = null;
                }

            }
        }
    }

    public bool IsTimerComplete()
    {
        return timer <= 0f;
    }

    public float _GetTimer()
    {
        return timer;
    }
}
