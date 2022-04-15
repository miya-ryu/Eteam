using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    Button Stage1;
    Button Stage2;
    Button Stage3;

    void Start()
    {
        Stage1 = GameObject.Find("/Canvas/Stage1").GetComponent<Button>();
        Stage2 = GameObject.Find("/Canvas/Stage2").GetComponent<Button>();
        Stage3 = GameObject.Find("/Canvas/Stage3").GetComponent<Button>();

        //最初に選択状態にするボタン
        Stage1.Select();
    }

    void Update()
    {
        
    }
}
