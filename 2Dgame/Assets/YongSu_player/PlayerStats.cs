using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP;
    public GameObject endpanel;
    public GameObject endpanelbg;
    private void Start()
    {
        endpanel.SetActive(false);
        endpanelbg.SetActive(false);
        HP = 100f;
    }
    private void Update()
    {
        LowHp();
    }

    private void LowHp()
    {
        HP -= Time.deltaTime;
        if( HP <= 0)
        {
            Time.timeScale = 0f;
            endpanel.SetActive(true);
            endpanelbg.SetActive(true);
        }
    }
}
