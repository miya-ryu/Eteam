using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heartcount : MonoBehaviour
{
    public GameObject heart, heart1, heart2;
    float lifecount = 3;
    const float MAX = 3;
    float count;
    bool CAttack= PlayerMove2.ChargeAttack ;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Damage();
        //lifeup();
        count += Time.deltaTime;
        CAttack = PlayerMove2.ChargeAttack;　//PlayerMove2スクリプトのChargeAttackを代入

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (count > 2)
            {
                if (CAttack == false) //攻撃をしていなければ
                {

                    lifecount--;
                    count = 0;
                }
            }

            if (lifecount < 0)
            {
                lifecount = 0;
            }
        }

        //if (this.gameObject.tag == "")
        //{
        //    //Debug.Log("回復した");
        //    lifecount++;
        //    lifecount = System.Math.Min(lifecount, MAX);
        //    //Debug.Log(lifecount);
        //}

    }

    void Damage()
    {
        
        if (lifecount == 2)
        {
            heart.SetActive(false);
            Debug.Log("ハートが2です");
        }
        if (lifecount == 1)
        {
            heart1.SetActive(false);
            Debug.Log("ハートが1です");
        }
        if (lifecount == 0)
        {
            heart2.SetActive(false);
            SceneManager.LoadScene("TitleScene");
            Debug.Log("ハートが0です");
        }

    }
    //void lifeup()
    //{
    //    if (lifecount == 3|| heart2==false)
    //    {
    //        heart2.SetActive(true);
    //    }
    //    if(lifecount == 2 || heart1 == false)
    //    {
    //        heart1.SetActive(true);
    //    }
    //}
   
}

