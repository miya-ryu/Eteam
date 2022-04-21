using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;

    

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {

        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;

           

            // パーティクルを発生させる。
            newParticle.Play();

            //このGameObjectを削除
            Destroy(this.gameObject,1.8f);

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 4.0f);

            
        }
    }
}