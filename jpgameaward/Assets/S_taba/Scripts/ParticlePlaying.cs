using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlaying : MonoBehaviour
{
    private bool isPlaying;
    [SerializeField] ParticleSystem Chargeparticle;
    [SerializeField] ParticleSystem Circleparticle;
    [SerializeField] ParticleSystem ChargeShock1;
    [SerializeField] ParticleSystem ChargeShock2;

    //[SerializeField] ParticleSystem test;

    public int cnt = 0;    //溜め時間を管理する変数
    const int MAXCNT = 60; //溜まりきる時間を格納する変数

    // Start is called before the first frame update
    void Start()
    {
        Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //ChargeShock1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //ChargeShock2.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("B") || Input.GetKey(KeyCode.Space))//Bボタンで長押しで溜めエフェクト
        {
            cnt++;
            if (cnt == 60)
            {//60フレームで溜まりきる
                ChargeShock1.gameObject.SetActive(true);　//ショックウェーブのオブジェクトを表示
                ChargeShock2.gameObject.SetActive(true);  //ショックウェーブのオブジェクトを表示

                ChargeShock1.Play(true);                  //ショックウェーブを再生
                ChargeShock2.Play(true);                  //ショックウェーブを再生

                if (ChargeShock1 == true)
                {
                    Invoke("ShockWaveStop", 1f);          //1秒後にショックウェーブを止める関数を呼ぶ
                }


                //test.gameObject.SetActive(true);
                //test.Play(true);
            }

            Chargeparticle.Play(true);      //溜めエフェクトを再生
            Circleparticle.Play(true);      //溜めエフェクトを再生

            Circleparticle.gameObject.SetActive(true);//溜めエフェクトのオブジェクトを表示

        }
        else//キーを離したら
        {
            cnt = 0;    //カウントを0にする
            Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            //ChargeShock1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            //ChargeShock2.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            Circleparticle.gameObject.SetActive(false);

            ChargeShock1.gameObject.SetActive(false);
            ChargeShock2.gameObject.SetActive(false);


            //test.gameObject.SetActive(false);

        }
    }
    void ShockWaveStop() //ショックウェーブを止める関数
    {
        ChargeShock1.gameObject.SetActive(false);
        ChargeShock2.gameObject.SetActive(false);
    }
}
