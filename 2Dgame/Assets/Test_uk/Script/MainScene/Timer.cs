using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI time;
    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
                
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
