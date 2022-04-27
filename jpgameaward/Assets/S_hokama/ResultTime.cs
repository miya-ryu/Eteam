using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    public Text timeText;
    public Text EnemycountText;

    string resulttime= Time_Down.time;
    int Enemycount = Attckwall.Enemycount;
    int Allenemy = Attckwall.AllEnemy;

    void Start()
    {
        timeText.text = string.Format("残り時間　    {0}", resulttime);
        EnemycountText.text = string.Format("倒した敵    　{0}/{1}",Allenemy-Enemycount,Allenemy );   
    }
}
