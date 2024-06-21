using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public Button closeButton;
    public Button rangedButton;
    public Button startButton;
  

    void Start()
    {
        closeButton.onClick.AddListener(() => SelectButton(0));
        rangedButton.onClick.AddListener(() => SelectButton(1));
        startButton.onClick.AddListener(OnGameStartClick);
    }

    void SelectButton(int playerid)
    {
        GameManager.Instance.SetCharacterId(playerid);
        Debug.Log("Selected Button: " + playerid);
    }

    public void OnGameStartClick()
    {
        SceneManager.LoadScene("MainScene"); // 변경할 씬 이름
    }
}
