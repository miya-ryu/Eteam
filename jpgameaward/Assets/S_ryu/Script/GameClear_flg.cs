using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear_flg : MonoBehaviour
{
    [SerializeField] GameObject ClearPanel;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Time_Down;
    [SerializeField] GameObject PlayerHART;
    [SerializeField] GameObject Help;

    public SoundScript GameClearClip;

    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示するText型の変数
    public Text ClearTextTime;

    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        ClearTextTime.text = countdown.ToString("f1");

        //ゲームクリアを表示
        ClearPanel.SetActive(true);

        //ポーズ画面を表示できなくする
        Pause.GetComponent<GameManager>().enabled = false;

        //制限時間を止める
        Time_Down.GetComponent<Time_Down>().enabled = false;

        //体力が減らないようにする
        PlayerHART.GetComponent<PlayerHERT>().enabled = false;

        //ヘルプを非表示にする
        Help.SetActive(false);

        GameClearClip.GameClear();

        if (countdown <= 0)
        {
            //リザルト画面へ
            SceneManager.LoadScene("ResultScene");
        }
    }
}
