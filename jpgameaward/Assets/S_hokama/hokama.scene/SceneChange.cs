using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    void Update()
    {
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

    }
}