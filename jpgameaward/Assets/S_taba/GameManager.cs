using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //カウントダウン変数
    public static float countdown;

    //ポーズ画面
    public static int pause;
    private int MenuSelect = 0;

    [SerializeField] GameObject PausePanel;     //ポーズ画面
    [SerializeField] GameObject Player;     //ポーズ画面

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void InitGame()
    {
        countdown = 4.0f;
        pause = 0;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        Player.GetComponent<PlayerMove2>().enabled = true;
    }

    void Pause() //ポーズ画面
    {
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == 0)
            {
                Debug.Log("escキーが押された。");
                PausePanel.SetActive(true);
                //GameBGM.Pause();
                pause = 1;
                Player.GetComponent<PlayerMove2>().enabled = false;
                Time.timeScale = 0f;
            }
            else
            {
                PausePanel.SetActive(false);
                //GameBGM.UnPause();
                pause = 0;
                Time.timeScale = 1f;
                Player.GetComponent<PlayerMove2>().enabled = true;
            }
        }
        else
        {
            
        }
    }

    public void Retry()
    {
        //リトライ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Title()
    {
        //タイトルシーンへ
        SceneManager.LoadScene("TitleScene");
    }
}
