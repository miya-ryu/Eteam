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

    [SerializeField] float speed;
    public GameObject target;

    public Vector3 hitpoint;

    private Rigidbody rb;         // Rigidbodyを使うための変数

    public bool flag;

    private void Start()
    {
        speed = 1f;
        flag = false;
        rb = GetComponent<Rigidbody>(); //rbにRigidbodyを代入
    }

    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        //Rayを飛ばす方向
        Vector3 temp = other.transform.position - transform.position;
        direction = temp.normalized;

        ray = new Ray(transform.position, direction);　　　　　　　　　　//Rayを飛ばす
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);  //Rayをシーン上に描画

        //Rayが最初に当たった物体を調べる
        if (Physics.Raycast(ray.origin, ray.direction * distance, out hit))
        //hit = Physics.RaycastAll(ray).First();
        {

            Vector3 hitpoint = hit.point;

            //transform.position = Vector3.MoveTowards(transform.position, hitpoint, speed);

            if (hit.collider.CompareTag("Enemy"))
            {
                //Debug.Log("敵発見");
                //Debug.Log(hit.point);//デバッグログにヒットした場所を出す

                if (Input.GetButtonUp("B") || Input.GetKeyDown(KeyCode.Space))
                {
                    if (flag == false)
                    {
                        flag = true;
                    }
                    //this.transform.position =
                    //    new Vector3(this.transform.position.x, hitpoint.y, hitpoint.z);//test2 zだけ

                }
            }

            if(flag == true)
            {
                AttackMove();
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("フラグオフ");
            flag = false ;
        }
    }
    void AttackMove()  //攻撃した時の移動
    {
        transform.position = Vector3.MoveTowards(transform.position, hit.point, speed);

        if(this.transform.position == hit.point)
        {
            flag = false;
        }
    }

    void flagoff()
    {
        flag = false;
    }
}
