using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SelfDestroy : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //パーティクルが終了したか判別
        if (particle.isStopped)
        {
            //パーティクル用ゲームオブジェクトを削除
            Destroy(this.gameObject);
        }
    }
}