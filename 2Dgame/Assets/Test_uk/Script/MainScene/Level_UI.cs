using UnityEngine;
using UnityEngine.UI;

public class Level_UI : MonoBehaviour
{
    public float curExp;   // ���� ȹ�� ����ġ 
    public float maxExp;   // �ʿ� ����ġ
    public Image expBar;   // ����ġ�� ���� �ʿ�

    private void Start()
    {
        curExp = 0;
    }

    private void Update()
    {
        //expBar.fillAmount = GetPercentage();
    }

    public float GetPercentage()
    {
        return curExp / maxExp;
    }
}
