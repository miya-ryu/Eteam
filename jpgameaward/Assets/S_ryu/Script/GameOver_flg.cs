using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_flg : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject BGM;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Help;

    //SoundScript の GameOver 関数を取得
    public SoundScript GameOverClip;

    void Start()
    {
        GameOverClip.GameOver();
    }

    void Update()
    {
        //ゲーム内時間を止める
        Time.timeScale = 0f;

        //ゲームオーバーを表示
        GameOverPanel.SetActive(true);

        //BGM を止める
        BGM.SetActive(false);

        //ポーズ画面を表示できなくする
        Pause.GetComponent<GameManager>().enabled = false;

        //プレイヤーを操作できなくする
        Player.GetComponent<PlayerMove2>().enabled = false;

        //ヘルプを非表示にする
        Help.SetActive(false);
    }
}
