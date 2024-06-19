using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu; 
    [SerializeField] private GameObject storeMenu;
    
    public void StartMainScene()
    {
        // ���� �� �����ϱ�
        SceneManager.LoadScene("MainScene");
    }

    public void ShowOptionMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void ShowStoreMenu()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}