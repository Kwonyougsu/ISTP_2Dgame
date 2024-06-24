using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public Button closeButton;
    public Button rangedButton;
    public Button RotationButton;
    public Button startButton;
  

    void Start()
    {
        closeButton.onClick.AddListener(() => SelectButton(0));
        rangedButton.onClick.AddListener(() => SelectButton(1));
        RotationButton.onClick.AddListener(() => SelectButton(2));
        startButton.onClick.AddListener(OnGameStartClick);
    }

    void SelectButton(int playerid)
    {
        GameManager.Instance.SetCharacterId(playerid);
        Debug.Log("Selected Button: " + playerid);
    }

    public void OnGameStartClick()
    {
        GameManager.Instance.StageDataReset();
        SceneManager.LoadScene("MainScene_yong"); // 변경할 씬 이름
    }
}
