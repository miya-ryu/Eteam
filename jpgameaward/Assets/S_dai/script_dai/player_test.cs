using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_test : MonoBehaviour
{
    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;
    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))//  もし、Aボタンがおされたなら、
        {
            if (Ground == true)//  もし、Groundedがtrueなら、
            {
                Debug.Log("a");
                Ground = false;
                inJumping = true;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0.5f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Ground = true;//  Groundedをtrueにする
            inJumping = false;
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class player_test : MonoBehaviour
//{
//    //プレイヤーフラグ
//    [SerializeField] public bool inJumping = false;

//    private Rigidbody rb; // Rigidbodyを使うための変数
//    private bool Ground; // 地面に着地しているか判定する変数
//    public float Jumppower; // ジャンプ力
//    public float speed = 25f; //キャラクターの移動スピード

//    //SimpleAnimation変数
//    SimpleAnimation simpleAnimation;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();//  rbにRigidbodyを代入
//        //キャラクターが回転してしまわないように回転方向を固定する
//        rb.constraints = RigidbodyConstraints.FreezeRotation;
//    }

//    void Update()
//    {
//        //横移動とダッシュ
//        //float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
//        //transform.position = new Vector3(transform.position.x + dx, transform.position.y);
//        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0);

//        if (Input.GetButton("X"))
//        {
//            //Debug.Log("このボタン");
//            // joystick button 0 A
//            // joystick button 1 B
//            // joystick button 2 X
//            // joystick button 3 Y
//            // joystick button 4 LB
//            // joystick button 5 RB
//            // joystick button 6 BACK
//            // joystick button 7 START
//            // joystick button 8 L3
//            // joystick button 9 R3
//        }

//        //Aボタンでジャンプ
//        if (Input.GetButton("A"))//  もし、Aボタンがおされたなら、
//        {
//            if (Ground == true)//  もし、Groundedがtrueなら、
//            {
//                Ground = false;
//                inJumping = true;
//                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
//            }
//        }
//    }

//    //地面との判定
//    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
//    {
//        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
//        {
//            Ground = true;//  Groundedをtrueにする
//            inJumping = false;
//        }
//    }
//}

