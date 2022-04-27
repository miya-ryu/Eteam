using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePush : MonoBehaviour
{


    public void PushButton()
    {
        SceneManager.LoadScene("matayoshi1");
    }
    //SceneManager.LoadScene("SampleScene 2");
    public void PushButton2()
    {
        SceneManager.LoadScene("matayoshi");
    }

    //public void PushButton3()
    //{
    //    SceneManager.LoadScene("");
    //}
}
