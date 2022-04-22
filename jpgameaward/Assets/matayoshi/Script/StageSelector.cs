﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{
    private int stageNumber; //ステージ開放条件の値を格納

    //ステージ1はゲームスタート時に解放されているのでstage2から
    public Text Stage2;
    public Text Stage3;

    void Start()
    {
        stageNumber = PlayerPrefs.GetInt("stageNumber");
    }


    void Update()
    {
        if (stageNumber >= 2)
        {
            Stage2.text = "荒れた広野"; //ステージ2の名前
        }

        if (stageNumber >= 3)
        {
            Stage3.text = "滑稽の洞窟"; //ステージ3の名前
        }
    }
}