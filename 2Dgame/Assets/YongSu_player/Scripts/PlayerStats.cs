using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP;
    public float Power;
    public GameObject endpanel;
    public GameObject endpanelbg;
    private void Start()
    {
        endpanel.SetActive(false);
        endpanelbg.SetActive(false);
        HP = 100f;
        Power = 1.0f;
    }
    private void Update()
    {
        LowHp();
    }

    public void LowHp(float damage = 0)
    {
        HP -= damage;
        
        if (HP <= 0)
        {
            Time.timeScale = 0f;
            endpanel.SetActive(true);
            endpanelbg.SetActive(true);
        }
    }
}
