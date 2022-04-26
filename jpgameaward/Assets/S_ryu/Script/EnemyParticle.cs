using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;
    [SerializeField] private ParticleSystem blood;

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

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;

            // パーティクルを発生させる。
            newParticle.Play();

            //このGameObjectを削除
            Destroy(this.gameObject);

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 4.0f);
        }
    }
}