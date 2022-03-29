using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onistatus : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;

    //Oniの体力
    private float Oni_hp = 3;

    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    public SpriteRenderer sp;
    private bool isDamage = false;

    private void Start()
    {
        //キャラクターのSimpleAnimationを取得
        simpleAnimation = this.GetComponent<SimpleAnimation>();

        simpleAnimation.CrossFade("Walk", 0.1f);
    }

    private void Update()
    {
        Damage();

        if(isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // katana タグの付いたゲームオブジェクトと衝突したら
        if (other.gameObject.tag == "KATANA")
        {
            Debug.Log("ヒット");
            Oni_hp--;
            isDamage = true;
            StartCoroutine(OnDamage());
        }
    }

    void Damage()
    {
        if(Oni_hp == 2 || Oni_hp == 1)
        {
            //simpleAnimation.CrossFade("Hit", 0.6f);
        }
        if(Oni_hp == 0)
        {
            simpleAnimation.CrossFade("Dead", 0.1f);

            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;

            // パーティクルを発生させる。
            newParticle.Play();

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 4.0f);

            //このGameObjectを削除
            Destroy(this.gameObject, 0.8f);
        }
    }

    public IEnumerator OnDamage()
    {

        yield return new WaitForSeconds(3.0f);

        // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);

    }
}