using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public BoxCollider boxcol;

    void Start()
    {
        boxcol.enabled = false;
    }

    void Update()
    {
        if(boxcol.enabled == false && Input.GetButton("B"))
        {
                Debug.Log("押された");
                boxcol.enabled = true;
        }
        else
        {
            boxcol.enabled = false;
        }
    }
}
