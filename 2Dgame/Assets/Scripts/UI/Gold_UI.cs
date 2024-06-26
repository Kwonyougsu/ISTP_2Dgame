using UnityEngine;
using UnityEngine.UI;

public class Gold_UI : MonoBehaviour
{
    public int getGold = 0;     // ���ӿ��� ȹ���� ��� ����
    public Text goldText;       // ȹ�� ��� UI ����

    private void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int value)
    {
        getGold += value;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = getGold.ToString();
    }
}
