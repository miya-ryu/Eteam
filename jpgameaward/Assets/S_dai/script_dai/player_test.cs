using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_test : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    transform.Translate(0.5f, 0f,0f);
        //}
    }
}

