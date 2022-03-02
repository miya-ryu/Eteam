using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;

    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力
    public float speed = 25f; //キャラクターの移動スピード

    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyを代入
        //キャラクターが回転してしまわないように回転方向を固定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //キャラクターのSimpleAnimationを取得
        simpleAnimation = this.GetComponent<SimpleAnimation>();
    }

    void Update()
    {
        //横移動とダッシュ
        //float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //transform.position = new Vector3(transform.position.x + dx, transform.position.y);
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0);

        if (Input.GetButton("X"))
        {
            //Debug.Log("このボタン");
            // joystick button 0 A
            // joystick button 1 B
            // joystick button 2 X
            // joystick button 3 Y
            // joystick button 4 LB
            // joystick button 5 RB
            // joystick button 6 BACK
            // joystick button 7 START
            // joystick button 8 L3
            // joystick button 9 R3
        }

        //Aボタンでジャンプ
        if (Input.GetButton("A"))//  もし、Aボタンがおされたなら、
        {
            if (Ground == true)//  もし、Groundedがtrueなら、
            {
                Ground = false;
                inJumping = true;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
            }
        }

        //アニメーションの再生(ダッシュ中)
        if (pos.magnitude > 0.1) //posからベクトルの長さを取得
        {
            //posの方向に回転
            transform.rotation = Quaternion.LookRotation(pos);

            //現在のキャラクターの位置を基準に移動
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (inJumping == true) //ジャンプ中のとき
            {
                simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
                //ジャンプしながらBボタンでアタック
                if (Input.GetButton("B"))
                {
                    simpleAnimation.CrossFade("attack", 0.1f);
                }
            }
            else
            {
                simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
                //ダッシュしながらBボタンでアタック
                if (Input.GetButton("B"))
                {
                    simpleAnimation.CrossFade("attack", 0.1f);
                }
            }
        }
        //アニメーションの再生(止まっている時)
        else if (inJumping == true) //ジャンプしたとき
        {
            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
            //ジャンプしながらBボタンでアタック
            if (Input.GetButton("B"))
            {
                simpleAnimation.CrossFade("attack", 0.1f);
            }
        }
        else
        //Bボタンでアタック
        if (Input.GetButton("B"))
        {
            simpleAnimation.CrossFade("attack", 0.1f);
        }
        else
        {
            simpleAnimation.Play("Default");        //デフォルトアニメーションを再生
        }
    }

    //地面との判定
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Ground = true;//  Groundedをtrueにする
            inJumping = false;
        }            simpleAnimation.Play("Default");        //デフォルトアニメーションを再生
    }
}