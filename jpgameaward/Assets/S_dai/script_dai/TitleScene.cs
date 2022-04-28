using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    Button button;

    //SoundScript の Push 関数を取得
    public SoundScript PushClip;

    void Start()
    {
        button = GameObject.Find("Canvas/GameOverPanel/SelectButton/Button").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }

    void Update()
    {
        //Aボタンが押されたら
        if (Input.GetButton("A"))
        {
            //ゲーム内時間を戻す
            Time.timeScale = 1f;

            PushClip.Push();
        }
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