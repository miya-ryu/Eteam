using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public MeshCollider meshcol;

    void Start()
    {
        meshcol.enabled = false;
    }

    public void AttackStart()
    {
        meshcol.enabled = true;
    }

    public void AttackEnd()
    {
        meshcol.enabled = false;
    }
}
