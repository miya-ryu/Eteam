using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public SphereCollider spherecol;

    //溜め攻撃の変数、フラグ
    bool ChargeAttack = false;
    int ChargeAttackCount;
    int ChargeTime = 60;  //溜め時間

    void Start()
    {
        spherecol.enabled = true;
    }

    void Update()
    {
        //溜め攻撃
        if (Input.GetButtonUp("B"))
        {
            //押している時間が ChargeTime より多いとき
            if (ChargeTime <= ChargeAttackCount)
            {
                ChargeAttackCount = 0;
                ChargeAttack = true;
            }
        }
        if (Input.GetButton("B"))
        {
            ChargeAttackCount++;
        }
        else
        {
            ChargeAttackCount = 0;
        }

        // spherecol が表示されている時
        if(spherecol.enabled == true)
        {
            //溜め攻撃が true の時
            if (ChargeAttack == true)
            {
                spherecol.enabled = false;
                Invoke("Chargeflg", 0.6f);
            }
        }
        else
        {
            spherecol.enabled = true;
        }
    }
    //溜め攻撃フラグ
    void Chargeflg()
    {
        ChargeAttack = false;
    }
}
