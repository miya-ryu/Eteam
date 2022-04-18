using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/GameOverPanel/SelectButton/Button").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }

    void Update()
    {
        //Aボタンが押されたら
        if (Input.GetKeyDown("joystick button 0"))
        {
            //ゲーム内時間を戻す
            Time.timeScale = 1f;
        }
    }
}
