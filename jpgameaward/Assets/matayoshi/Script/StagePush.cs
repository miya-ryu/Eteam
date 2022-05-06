using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePush : MonoBehaviour
{
    //SoundScript の Push 関数を取得
    public SoundScript PushClip;

    public void PushButton()
    {
        SceneManager.LoadScene("SampleScene 2");

        PushClip.Push();
    }

    public void PushButton2()
    {
        PushClip.Push();

        SceneManager.LoadScene("Stage_Village");
    }
}
