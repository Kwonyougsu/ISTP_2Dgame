using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainSceneEndPanel : MonoBehaviour
{
    public TextMeshProUGUI endTextTime;
    public TextMeshProUGUI endTextGold;

    public Timer timer;
    private void Awake()
    {
        timer = GameManager.Instance.timer;
    }
    private void Update()
    {
        int minutes = Mathf.FloorToInt(timer.currentTime / 60);
        int seconds = Mathf.FloorToInt(timer.currentTime % 60);

        endTextTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        endTextGold.text = $"{GameManager.Instance.stageGold}";
    }
}
