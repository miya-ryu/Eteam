using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attckwall : MonoBehaviour
{
    bool CAttackflg = PlayerMove2.ChargeAttack;
    public BoxCollider col;

    GameObject[] enemyBox;
    public static int AllEnemy;
    public static int Enemycount;


    // Start is called before the first frame update
    void Start()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        AllEnemy = enemyBox.Length;

        col.enabled = false;
    }
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        Enemycount = enemyBox.Length;
        CAttackflg = PlayerMove2.ChargeAttack;
        if (CAttackflg == true)
        {
            col.enabled = true;
        }
        if (CAttackflg == false)
        {
            col.enabled = false;
        }
    }
}
