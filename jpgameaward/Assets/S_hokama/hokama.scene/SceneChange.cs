﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    int pause=GameManager.pause;
    void Update()
    {
        pause = GameManager.pause;
        
        if (SceneManager.GetActiveScene().name == "TitleScene" && Input.GetButton("start")) 　//シーンがTitleSceneの時startボタンが押されたら
        {
            SceneManager.LoadScene("SampleScene 2");
            //SceneManager.LoadScene("1Scene");
        }
        if (SceneManager.GetActiveScene().name == "SampleScene 2" && Input.GetButton("X"))　　　 //シーンが1Sceneの時startボタンが押されたら
        {
            SceneManager.LoadScene("ResultScene");
        }

        if (SceneManager.GetActiveScene().name == "ResultScene" && Input.GetButton("start"))  //シーンがResultSceneの時startボタンが押されたら
        {
            SceneManager.LoadScene("TitleScene");
        }
        if (SceneManager.GetActiveScene().name == "SampleScene 2" && pause == 1)
        {
            if (Input.GetButton("A"))
            {
                SceneManager.LoadScene("TitleScene");

            }
            if (Input.GetButton("B"))
            {
                SceneManager.LoadScene("SampleScene 2");
            }

        }

    }
}