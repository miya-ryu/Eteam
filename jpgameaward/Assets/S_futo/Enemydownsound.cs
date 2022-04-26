using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydownsound : MonoBehaviour
{
    //SoundScript の Enemy 関数を取得
    public SoundScript EnemyClip;

    private void OnTriggerEnter(Collider other)
    {
        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
            EnemyClip.Enemy();
        }
    }
}