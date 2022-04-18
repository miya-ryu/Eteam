using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attckwall : MonoBehaviour
{
    bool CAttackflg = PlayerMove2.ChargeAttack;
    public BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
    }
    void Update()
    {
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
