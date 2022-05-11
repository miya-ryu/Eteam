using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    private int stageNumber;
    public Button Stage2;
    public Text Stage2Text;

    void Start()
    {
        stageNumber = PlayerPrefs.GetInt("stageNumber");
        Stage2.interactable = false;
    }

    void Update()
    {
        if (stageNumber >= 2)
        {
            Stage2.interactable = true;
            Stage2Text.text = "ステージ２"; //ステージ2の名前
        }
    }
}
