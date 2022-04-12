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
    private int pause;
    private int MenuSelect = 0;

    [SerializeField] GameObject PausePanel;     //ポーズ画面

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
    }
    void Pause()
    {
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyUp(KeyCode.Escape))
        {
            if (pause == 0)
            {
                Debug.Log("escキーが押された。");
                PausePanel.SetActive(true);
                //GameBGM.Pause();
                pause = 1;

                Time.timeScale = 0f;
            }
            else
            {
                PausePanel.SetActive(false);
                //GameBGM.UnPause();
                pause = 0;
                Time.timeScale = 1f;
            }
        }
        else
        {
            ;
        }
    }
}
