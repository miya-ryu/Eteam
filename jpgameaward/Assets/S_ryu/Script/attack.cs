using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public MeshCollider meshcol;

    //溜め攻撃の変数、フラグ
    bool ChargeAttack = false;
    int ChargeAttackCount;
    int ChargeTime = 30;  //溜め時間

    void Start()
    {
        meshcol.enabled = false;
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

        // meshcol が非表示の時
        if (meshcol.enabled == false)
        {
            //溜め攻撃が true の時
            if (ChargeAttack == true)
            {
                meshcol.enabled = true;
                Invoke("Chargeflg", 0.6f);
            }
        }
        else
        {
            meshcol.enabled = false;
        }
    }
    //溜め攻撃フラグ
    void Chargeflg()
    {
        ChargeAttack = false;
    }
}
