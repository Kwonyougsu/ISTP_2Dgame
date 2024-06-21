using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public Button closeButton;
    public Button rangedButton;
    public Button startButton;
    private string selectedButtonName;

    void Start()
    {
        closeButton.onClick.AddListener(() => SelectButton("Close"));
        rangedButton.onClick.AddListener(() => SelectButton("Ranged"));
        startButton.onClick.AddListener(OnGameStartClick);
    }

    void SelectButton(string buttonName)
    {
        selectedButtonName = buttonName;
        Debug.Log("Selected Button: " + selectedButtonName);
    }

    void OnGameStartClick()
    {
        if (!string.IsNullOrEmpty(selectedButtonName))
        {
            PlayerPrefs.SetString("SelectedButton", selectedButtonName);
            PlayerPrefs.Save();
            Debug.Log("Game Started with selected button: " + selectedButtonName);
            SceneManager.LoadScene("MainScene_yong"); // 변경할 씬 이름
        }
        else
        {
            Debug.Log("No button selected");
        }
    }
}
