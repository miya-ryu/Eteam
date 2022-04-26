using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    [SerializeField] public int stageNum;

    void Update()
    {

    }

    public void OnDestroy()
    {
        SceneManager.LoadScene("ClearScene");
        StageOpen();
    }

    public void StageOpen()
    {
        PlayerPrefs.SetInt("stageNumber", stageNum);//PlayerPrefsでクリアしたステージ番号をセット
    }
}
