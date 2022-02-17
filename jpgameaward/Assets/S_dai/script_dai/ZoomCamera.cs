using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    Camera cam; //Main CameraのCamera

    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) //Iキーが押されていれば
        {
            cam.fieldOfView = cam.fieldOfView - 0.2f; //ズームイン。
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //Oキーが押されていれば
        {
            cam.fieldOfView = cam.fieldOfView + 0.2f; //ズームアウト。
        }
    }
}
