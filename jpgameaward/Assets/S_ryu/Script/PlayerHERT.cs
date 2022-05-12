using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHERT : MonoBehaviour
{
    public GameObject heart, heart1, heart2;
    float lifecount = 3;
    const float MAX = 3;
    float count;
    bool CAttack = PlayerMove2.ChargeAttack;
    [SerializeField] GameObject GameOver_flg;
    //SoundScript の Damage 関数を取得
    public SoundScript DamageClip;
    //SoundScript の Helse 関数を取得
    public SoundScript HelseClip;
    [SerializeField] private ParticleSystem kakifuku_Effect;
    [SerializeField] private GameObject Player;
    void Start()
    {
        count = 5f;
    }
    void Update()
    {
        Damage();
        lifeup();
        count += Time.deltaTime;
        //PlayerMove2 スクリプトの ChargeAttack を代入
        CAttack = PlayerMove2.ChargeAttack;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Konbou")
        {
            if (count > 2)
            {
                //攻撃をしていなければ
                if (CAttack == false)
                {
                    lifecount--;
                    //音を鳴らす
                    DamageClip.Damage();
                    count = 0;
                }
            }
            if (lifecount < 0)
            {
                lifecount = 0;
            }
        }
        if (other.gameObject.tag == "Helse")
        {
            if (lifecount == 3)
            {
            }
            else
            {
                ParticleSystem newParticle = Instantiate(kakifuku_Effect);
                //
                newParticle.transform.position = Player.transform.position;
                //
                newParticle.transform.parent = Player.gameObject.transform;
                //
                newParticle.Play();
                lifecount++;
                //音を鳴らす
                HelseClip.Helse();
                lifecount = System.Math.Min(lifecount, MAX);
                Destroy(other.gameObject, 0.1f);
            }
        }
    }
    void Damage()
    {
        if (lifecount == 2)
        {
            heart.SetActive(false);
        }
        if (lifecount == 1)
        {
            heart1.SetActive(false);
        }
        if (lifecount == 0)
        {
            heart2.SetActive(false);
            GameOver_flg.GetComponent<GameOver_flg>().enabled = true;
        }
    }
    void lifeup()
    {
        if (lifecount == 3 || heart == false)
        {
            heart.SetActive(true);
        }
        if (lifecount == 2 || heart1 == false)
        {
            heart1.SetActive(true);
        }
    }

}

