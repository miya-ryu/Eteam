using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmostion : MonoBehaviour
{

    // Update is called once per frame
    void FoxedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // スローモーションにする{
            Time.timeScale = 0.3f;
        }
        // 早さをもとに戻す
        else
        {
            Time.timeScale = 1f;
        }
    }
}
