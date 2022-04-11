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
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("");
            }
            else if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("");
            }
            else
            {
                Debug.Log("");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
