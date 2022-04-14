using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHERT : MonoBehaviour
{
    public GameObject heart, heart1, heart2;
    float lifecount =  3;
    const float MAX = 3;

    void Update()
    {
        Damage();
        //lifeup();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Konbou")
        {
            Debug.Log("ダメージをうけた");
            lifecount--;
        }

        //if (col.gameObject.name == "PointUp")
        //{
        //    //Debug.Log("回復した");
        //    lifecount++;
        //    lifecount = System.Math.Min(lifecount, MAX);
        //}
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
            SceneManager.LoadScene("TitleScene");
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

