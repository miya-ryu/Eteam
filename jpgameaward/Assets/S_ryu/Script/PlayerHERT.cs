using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHERT : MonoBehaviour
{
    public GameObject heart, heart1, heart2;
    float lifecount =  3;
    const float MAX = 3;

    float count;
    bool CAttack = PlayerMove2.ChargeAttack;

    [SerializeField] GameObject GameOver_flg;

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
            if(count > 2)
            {
                //攻撃をしていなければ
                if(CAttack == false)
                {
                    lifecount--;
                    count = 0;
                }
            }

            if(lifecount < 0)
            {
                lifecount = 0;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helse")
        {
            if(lifecount == 3)
            {
                
            }
            else
            {
                //Debug.Log("回復した");
                lifecount++;
                lifecount = System.Math.Min(lifecount, MAX);
                Destroy(collision.gameObject);
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

