using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{
    public int stage_num;
    public GameObject Stage2;
    public GameObject Stage3;

    void Start()
    {
        stage_num = PlayerPrefs.GetInt("SCORE", 0);
    }

    void Update()
    {
        if(stage_num >= 2)
        {
            Stage2.SetActive(true);
        }

        if (stage_num >= 3)
        {
            Stage3.SetActive(true);
        }
    }
}
