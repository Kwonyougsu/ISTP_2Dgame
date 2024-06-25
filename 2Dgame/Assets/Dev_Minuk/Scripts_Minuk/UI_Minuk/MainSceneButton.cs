using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    public AudioClip restartClip;
    public AudioClip GameSceneclip;

    public void RestartButton()
    {
        Time.timeScale = 1f;
        if(restartClip) SoundManager.PlayBGM(restartClip);
        GameManager.Instance.StageDataReset();
        SceneManager.LoadScene("MainScene");
    }

    public void GameSceneButton()
    {
        ObjectPool.Instance.CleanPool();
        Time.timeScale = 1f;
        if (GameSceneclip)  SoundManager.PlayBGM(GameSceneclip);
        GameManager.Instance.StageDataReset();
        SceneManager.LoadScene("GameScene");
    }
}
