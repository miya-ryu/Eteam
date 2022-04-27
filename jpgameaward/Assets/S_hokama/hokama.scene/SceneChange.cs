using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChange : MonoBehaviour
{
    //int pause=GameManager.pause;

    [SerializeField] private CanvasGroup a;
    [SerializeField] private CanvasGroup b;
    private bool b_alpah = false;
    private bool Serect = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) )
        {
            a.alpha = 1f;//変数aのalpha値を変更
            b.alpha = 0.5f;
            Serect = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            a.alpha = 0.5f;
            b.alpha = 1f;
            Serect = false;
        }
        if (Serect)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetButton("A"))
            {
                SceneManager.LoadScene("SampleScene 2");
            }
        }else if(Input.GetKey(KeyCode.Space) || Input.GetButton("A"))
        {
            EndGame();
        }

        //if (SceneManager.GetActiveScene().name == "TitleScene" && Input.GetButton("start")) 　//シーンがTitleSceneの時startボタンが押されたら
        //{
        //    SceneManager.LoadScene("StageSelect");
        //}
        //if (SceneManager.GetActiveScene().name == "ClearScene" && Input.GetButton("start")) 　//シーンがClearSceneの時startボタンが押されたら
        //{
        //    SceneManager.LoadScene("TitleScene");
        //}

        //if (SceneManager.GetActiveScene().name == "SampleScene 2" && pause == 1)
        //{
        //    if (Input.GetButton("A"))
        //    {
        //        SceneManager.LoadScene("TitleScene");
        //    }
        //    if (Input.GetButton("B"))
        //    {
        //        SceneManager.LoadScene("SampleScene 2");
        //    }
        //}
    }

    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}

