using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class main_camera : MonoBehaviour
{           

    GameObject playerObj;
    player_test player;
    Transform playerTransform;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<player_test>();
        playerTransform = playerObj.transform;
    }

    // カメラ、背景ないのところも表示調整必
    //void Update()
    //{
    //    transform.position = new Vector3(player.transform.position.x, 5, -10);

    //    if (transform.position.x < 0)
    //    {
    //        transform.position = new Vector3(0, 5, -10);
    //    }

    //    if (transform.position.x >= 18)
    //    {
    //        transform.position = new Vector3(18, 5, -10);
    //    }
    //}

    void LateUpdate()                                                                                                                   
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //横方向だけ追従
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }


}
