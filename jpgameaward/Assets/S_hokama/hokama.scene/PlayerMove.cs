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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;
    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力
    float speed = 18f;
    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    bool ChargeAttack=false;
    int ChargeAttackCount;
    int ChargeTime=150;  //溜め時間

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
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x + dx, transform.position.y);
        

        
        if (Input.GetButton("A"))//  もし、Aボタンがおされたなら、
        {
            if (Ground == true)//  もし、Groundedがtrueなら、
            {
                Ground = false;
                inJumping = true;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
            }
        }
        if (Input.GetButtonUp("B"))
        {
            if (ChargeTime <= ChargeAttackCount)　//押してる時間がChargeTimeより多い時
            {
                ChargeAttackCount = 0;
                ChargeAttack = true;
            }
        }
        if(Input.GetButton("B"))
        {
            ChargeAttackCount++;
        }
        else
        {
            ChargeAttackCount = 0;
        }
            //アニメーションの再生
            if (dx != 0)
        {
            if (inJumping == true) //ジャンプ中のとき
            {
                simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
            }
            //ダッシュキー押下時
            else if (Input.GetButton("X"))
            {
                simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
                speed = 18f;
                if (ChargeAttack == true)
                {
                    simpleAnimation.CrossFade("attack", 0.1f);
                    Invoke("Chargeflg", 0.8f);
                }
            }
            else
            {
                simpleAnimation.CrossFade("Run", 0.1f);         //普通移動アニメーションを再生
                speed = 12f;
                if (ChargeAttack == true)
                {

                    simpleAnimation.CrossFade("attack", 0.1f);
                    Invoke("Chargeflg", 0.8f);
                }
            }
        }
        else if (inJumping == true) //ジャンプ中のとき
        {
            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
        }
        else
        //アタックテスト
        if (ChargeAttack == true)
        {
            transform.position += new Vector3(2, 0, 0) * Time.deltaTime*speed;
            simpleAnimation.CrossFade("attack", 0.1f);
            Invoke("Chargeflg",0.8f);
        }
        else
        {
            simpleAnimation.Play("Default");        //デフォルトアニメーションを再生
        }

    }
    ////地面との判定
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Ground = true;//  Groundedをtrueにする
            inJumping = false;
        }
    }
    void Chargeflg()
    {
        ChargeAttack = false;
    }
}