using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime1 : MonoBehaviour
{
    public Text timeText;
    public Text EnemycountText;
    [SerializeField] GameObject ClearText;

    string resulttime= Time_Down1.time;
    int Enemycount = Attckwall.Enemycount;
    int Allenemy = Attckwall.AllEnemy;

    void Start()
    {
        ClearText.SetActive(false);
        timeText.text = string.Format("残り時間　    {0}", resulttime);
        EnemycountText.text = string.Format("倒した敵    　{0}/{1}",Allenemy-Enemycount,Allenemy );   
    }

    void Update()
    {
        if (Allenemy - Enemycount == Allenemy)
        {
            ClearText.SetActive(true);
        }
    }
}
