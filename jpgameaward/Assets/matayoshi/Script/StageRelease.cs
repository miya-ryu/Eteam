using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageRelease : MonoBehaviour
{
    private int stageNumber;

    public Text Stage2;
    public Text Stage3;

    void Start()
    {
       stageNumber = PlayerPrefs.GetInt("stageNumber");
    } 

    void Update()
    {
        if (stageNumber >= 2)
        {
            Stage2.text = "Stage2"; //ステージ2の名前
        }

        if (stageNumber >= 3)
        {
            Stage3.text = "Stage3"; //ステージ3の名前
        }
    }
}
