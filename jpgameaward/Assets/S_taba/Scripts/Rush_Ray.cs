using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class Rush_Ray : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Vector3 direction;  //Rayを飛ばす方向
    float distance = 10;//Rayを飛ばす距離
    Vector3 pos;        //移動の座標格納用
    float step;         //移動用

    private void OnTriggerStay(Collider other)
    {
        //Rayを飛ばす方向
        Vector3 temp = other.transform.position - transform.position;
        direction = temp.normalized;

        ray = new Ray(transform.position, direction);　　　　　　　　　　//Rayを飛ばす
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);  //Rayをシーン上に描画

        //Rayが最初に当たった物体を調べる
        //if(Physics.Raycast(ray.origin,ray.direction * distance,out hit))
        hit = Physics.RaycastAll(ray).First();
        {
            pos = hit.point;
            pos.y = 1f;
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("敵発見");

                if(Input.GetKeyUp(KeyCode.Space))
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos, step);
                }

            }
            //else if (hit.collider.CompareTag("Ground"))
            //{
            //    Debug.Log("");
            //}
            else
            {
                Debug.Log("何もない");
            }
        }
    }
}
