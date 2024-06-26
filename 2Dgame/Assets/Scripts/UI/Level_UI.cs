using UnityEngine;
using UnityEngine.UI;

public class Level_UI : MonoBehaviour
{
    public float curExp;   // 현재 획득 경험치 
    public float maxExp;   // 필요 경험치
    public Image expBar;   // 경험치바 연결 필요

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
