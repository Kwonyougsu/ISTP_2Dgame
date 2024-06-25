using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu; 
    [SerializeField] private GameObject storeMenu;
    [SerializeField] private GameObject characterselectMenu;
    [SerializeField] private GameObject charactercloseMenu;
    [SerializeField] private GameObject MainText;

    //public void StartMainScene()
    //{
    //    // 게임 씬 변경하기
    //    SceneManager.LoadScene("MainScene");
    //}

    public void ShowOptionMenu()
    {
        mainMenu.SetActive(false);
        MainText.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void ShowStoreMenu()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
        UIStore.instance.ClearStore();
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void ShowCharacterselectMenu()
    {
        mainMenu.SetActive(false);
        MainText.SetActive(false);
        characterselectMenu.SetActive(true);
    }

    public void CloseCharacterselectMenu()
    {
        mainMenu.SetActive(true);
        MainText.SetActive(true);
        characterselectMenu.SetActive(false);
    }
}
