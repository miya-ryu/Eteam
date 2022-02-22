using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class P : MonoBehaviour
{
    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;
    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力
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
    // Update is called once per frame
    void Update()
    {
        //横移動とダッシュ
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0f, 0f, -0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0f, 0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0f, 0f, -0.25f);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0f, 0f, 0.25f);
        }
        //スペースでジャンプ
        if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、
        {
            if (Ground == true)//  もし、Groundedがtrueなら、
            {
                Ground = false;
                inJumping = true;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
            }
        }
        //アニメーションの再生
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (inJumping == true) //ジャンプ中のとき
            {
                simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
            }
            //ダッシュキー押下時
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
            }
            else
            {
                simpleAnimation.CrossFade("Run", 0.1f);         //普通移動アニメーションを再生
            }
        }
        else if (inJumping == true) //ジャンプ中のとき
        {
            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
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
        }
    }
}