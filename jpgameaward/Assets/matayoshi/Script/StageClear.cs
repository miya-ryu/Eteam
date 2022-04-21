using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    [SerializeField] public int stageNum; //このボスが登場するステージ番号をインスペクターに指定

    void Update()
    {

    }

    public void StageOpen()
    {
        PlayerPrefs.SetInt("stageNumber", stageNum);//PlayerPrefsでクリアしたステージ番号をセット
    }
    public void OnDestroy()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
