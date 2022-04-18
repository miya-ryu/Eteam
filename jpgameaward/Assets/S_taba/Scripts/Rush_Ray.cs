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

    //test2
    [SerializeField] GameObject player;

    public float speed;
    public GameObject target;

    private void Start()
    {
        speed = 1f;
    }

    //void Update()
    //{
    //    //自分の位置、ターゲット、速度
    //    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    //}

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

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("敵発見");
                Debug.Log(hit.point);//デバッグログにヒットした場所を出す

                if (Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.Space))
                {
                    //transform.position = Vector3.MoveTowards(transform.position, pos, step);//test1

                    //this.transform.position = hit.point;//test2

                    Vector3 hitpoint = hit.point;

                    //this.transform.position =
                    //    new Vector3(this.transform.position.x, hitpoint.y, hitpoint.z);//test2 zだけ

                    transform.position = Vector3.MoveTowards(transform.position, hitpoint, speed);
                    Invoke("Moves", 0f);
                }

            }
            else
            {
                Debug.Log("何もない");
            }
        }
    }
    IEnumerator MoveUp()
    {
        while (direction.y < 3.0f)
        {
            direction = transform.position;
            transform.Translate(hitpoint.x, 0.02f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
