using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heartcount : MonoBehaviour
{
    public GameObject heart, heart1,heart2;
    float lifecount =  3;
    const float MAX = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        lifeup();

        

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PointDown")
        {
            //Debug.Log("ダメージをうけた");
            lifecount--;
            //Debug.Log(lifecount);
        }

        if (col.gameObject.name == "PointUp")
        {
            //Debug.Log("回復した");
            lifecount++;
            lifecount = System.Math.Min(lifecount, MAX);
            //Debug.Log(lifecount);
        }
    }
    void Damage()
    {
        if (lifecount == 2)
        {
            heart2.SetActive(false);
        }
        if (lifecount == 1)
        {
            heart1.SetActive(false);
        }
        if (lifecount == 0)
        {
            heart.SetActive(false);
            SceneManager.LoadScene("2scene");
        }

    }
    void lifeup()
    {
        if (lifecount == 3|| heart2==false)
        {
            heart2.SetActive(true);
        }
        if(lifecount == 2 || heart1 == false)
        {
            heart1.SetActive(true);
        }
    }
}

