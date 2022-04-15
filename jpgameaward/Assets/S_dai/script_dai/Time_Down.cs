using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Down : MonoBehaviour
{
    [SerializeField] GameObject GameOver_flg;

    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示するText型の変数
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            GameOver_flg.GetComponent<GameOver_flg>().enabled = true;
        }
    }
}