using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public MeshCollider meshcol;

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
