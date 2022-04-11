using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("見つけました");
            if (Input.GetButtonDown("RB"))
            {
                Debug.Log("敵を見ました");
            }
        }
        
        
    }
}
