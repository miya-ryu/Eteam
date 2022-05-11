using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    int pause=GameManager.pause;

    //SoundScript の Push 関数を取得
    public SoundScript PushClip;

    void Update()
    {   
        pause = GameManager.pause;

        if (SceneManager.GetActiveScene().name == "TitleScene" && Input.GetButton("A")) 　//シーンがTitleSceneの時Aボタンが押されたら
        {
            SceneManager.LoadScene("StageSelect");
        }

        if (SceneManager.GetActiveScene().name == "ResultScene" && Input.GetButton("A")) 　//シーンがClearSceneの時Aボタンが押されたら
        {
            PushClip.Push();

            SceneManager.LoadScene("TitleScene");
        }
        if (SceneManager.GetActiveScene().name == "ResultScene1" && Input.GetButton("A")) 　//シーンがClearSceneの時Aボタンが押されたら
        {
            PushClip.Push();

            SceneManager.LoadScene("TitleScene");
        }

        if (SceneManager.GetActiveScene().name == "SampleScene 2" && pause == 1)
        {
            if (Input.GetButton("A"))
            {
                PushClip.Push();

                SceneManager.LoadScene("TitleScene");
            }
            if (Input.GetButton("B"))
            {
                PushClip.Push();

                SceneManager.LoadScene("SampleScene 2");
            }
        }

        if (SceneManager.GetActiveScene().name == "Stage_Village" && pause == 1)
        {
            if (Input.GetButton("A"))
            {
                PushClip.Push();

                SceneManager.LoadScene("TitleScene");
            }
            if (Input.GetButton("B"))
            {
                PushClip.Push();

                SceneManager.LoadScene("Stage_Village");
            }
        }
    }
}