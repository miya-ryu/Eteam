using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_flg : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Help;

    void Update()
    {
        //ゲーム内時間を止める
        Time.timeScale = 0f;

        //ゲームオーバーを表示
        GameOverPanel.SetActive(true);

        //ポーズ画面を表示できなくする
        Pause.GetComponent<GameManager>().enabled = false;

        //プレイヤーを操作できなくする
        Player.GetComponent<PlayerMove2>().enabled = false;

        //ヘルプを非表示にする
        Help.SetActive(false);
    }
}
