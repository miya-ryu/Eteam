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

    public int cnt = 0;
    const int MAXCNT = 60;

    public int cnt1;

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
                ChargeShock1.gameObject.SetActive(true);
                ChargeShock2.gameObject.SetActive(true);

                ChargeShock1.Play(true);
                ChargeShock2.Play(true);

                if (ChargeShock1 == true)
                {
                    Invoke("ShockWaveStop", 1f);
                }


                //test.gameObject.SetActive(true);
                //test.Play(true);
            }

            Chargeparticle.Play(true);
            Circleparticle.Play(true);

            Circleparticle.gameObject.SetActive(true);

        }
        else//キーを離したら
        {
            cnt = 0;
            Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            //ChargeShock1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            //ChargeShock2.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            Circleparticle.gameObject.SetActive(false);

            ChargeShock1.gameObject.SetActive(false);
            ChargeShock2.gameObject.SetActive(false);


            //test.gameObject.SetActive(false);

        }
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    cnt1++;
        //    if (cnt1 == 60)
        //    {//120フレームで溜まりきる
        //        test.gameObject.SetActive(true);
        //        test.Play(true);
        //    }
        //}
        //else
        //{
        //    cnt1 = 0;
        //    test.gameObject.SetActive(false);
        //}
    }
    void ShockWaveStop()
    {
        ChargeShock1.gameObject.SetActive(false);
        ChargeShock2.gameObject.SetActive(false);
    }
}
