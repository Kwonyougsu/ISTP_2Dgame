using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float currentTime = 0f;

    private void Awake()
    {
        GameManager.Instance.timer = this;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
                
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
