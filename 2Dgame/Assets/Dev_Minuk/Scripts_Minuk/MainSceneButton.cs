using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{

    public void RestartButton()
    {
        Time.timeScale = 1f;
        GameManager.Instance.StageDataReset();
        SceneManager.LoadScene("MainScene");
    }

    public void GameSceneButton()
    {
        GameManager.Instance.StageDataReset();
        SceneManager.LoadScene("GameScene");
    }
}
