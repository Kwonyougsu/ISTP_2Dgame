using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject MainText;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        MainText.SetActive(true);
        optionMenu.SetActive(false);
    }
}
