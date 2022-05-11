using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle1 : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;
    [SerializeField] private ParticleSystem blood = null;

    //SoundScript の Enemy 関数を取得
    public SoundScript EnemyClip;

    private void OnTriggerEnter(Collider other)
    {
        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
            //音を鳴らす
            EnemyClip.Enemy();

            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);
            ParticleSystem newParticle1 = Instantiate(blood);

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;
            newParticle1.transform.position = this.transform.position;

            // パーティクルを発生させる。
            newParticle.Play();
            newParticle1.Play();

            //このGameObjectを削除
            Destroy(this.gameObject);

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 4.0f);
            Destroy(newParticle1.gameObject, 4.0f);
        }
    }
}