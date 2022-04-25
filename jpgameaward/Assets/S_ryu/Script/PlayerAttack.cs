using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //KATANA の MeshCollider を取得
    public MeshCollider meshcol;

    //SoundScript の Attack 関数を取得
    public SoundScript AttackClip;

    void Start()
    {
        meshcol.enabled = false;
    }

    public void AttackStart()
    {
        meshcol.enabled = true;
        AttackClip.Attack();
    }

    public void AttackEnd()
    {
        meshcol.enabled = false;
    }
}