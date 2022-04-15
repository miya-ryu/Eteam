using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    [SerializeField] private int stageNum; //このボスが登場するステージ番号をインスペクターに指定

    void Update()
    {
        
    }

    public void StageOpen()
    {
        PlayerPrefs.SetInt("stageNumber", stageNum);//PlayerPrefsでクリアしたステージ番号をセット
    }
}
