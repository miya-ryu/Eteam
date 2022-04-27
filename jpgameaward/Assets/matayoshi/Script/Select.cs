using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    private int stageNumber;

    Button Stage1;
    Button Stage2;

    void Start()
    {
        Stage1 = GameObject.Find("/Canvas/Stage1").GetComponent<Button>();
        Stage2 = GameObject.Find("/Canvas/Stage2").GetComponent<Button>();

        //最初に選択状態にするボタン
        Stage1.Select();

        //Stage2.interactable = false;
    }

    void Update()
    {
        //if (stageNumber >= 2)
        //{
        //    Stage2.interactable = true;
        //}
    }
}
