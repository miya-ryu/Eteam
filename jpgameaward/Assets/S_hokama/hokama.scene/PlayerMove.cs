//// joystick button 0 A
//// joystick button 1 B
//// joystick button 2 X
//// joystick button 3 Y
//// joystick button 4 LB
//// joystick button 5 RB
//// joystick button 6 BACK
//// joystick button 7 START
//// joystick button 8 L3
//// joystick button 9 R3

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class PlayerMove : MonoBehaviour
//{
//    //プレイヤーフラグ
//    [SerializeField] public bool inJumping = false;
//    private Rigidbody rb; // Rigidbodyを使うための変数
//    private bool Ground; // 地面に着地しているか判定する変数
//    public float Jumppower; // ジャンプ力
//    float speed = 18f;
//    //SimpleAnimation変数
//    SimpleAnimation simpleAnimation;

//    bool ChargeAttack=false;
//    int ChargeAttackCount;
//    int ChargeTime=120;  //溜め時間

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();//  rbにRigidbodyを代入
//        //キャラクターが回転してしまわないように回転方向を固定する
//        rb.constraints = RigidbodyConstraints.FreezeRotation;
//        //キャラクターのSimpleAnimationを取得
//        simpleAnimation = this.GetComponent<SimpleAnimation>();
//    }
//    void Update()
//    {
//        //横移動とダッシュ
//        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
//        transform.position = new Vector3(transform.position.x + dx, transform.position.y);



//        if (Input.GetButton("A"))//  もし、Aボタンがおされたなら、
//        {
//            if (Ground == true)//  もし、Groundedがtrueなら、
//            {
//                Ground = false;
//                inJumping = true;
//                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける

//            }
//        }
//        if (Input.GetButtonUp("B"))
//        {
//            if (ChargeTime <= ChargeAttackCount)　//押してる時間がChargeTimeより多い時
//            {
//                ChargeAttackCount = 0;
//                ChargeAttack = true;
//            }
//        }
//        if(Input.GetButton("B"))
//        {
//            ChargeAttackCount++;
//        }
//        else
//        {
//            ChargeAttackCount = 0;
//        }
//            //アニメーションの再生
//            if (dx != 0)
//        {
//            if (inJumping == true) //ジャンプ中のとき
//            {
//                simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
//            }
//            //ダッシュキー押下時
//            else if (Input.GetButton("X"))
//            {
//                simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
//                speed = 18f;
//                if (ChargeAttack == true)
//                {  
//                    simpleAnimation.CrossFade("attack", 0.1f);
//                    Invoke("Chargeflg", 0.8f);
//                }
//            }
//            else
//            {
//                simpleAnimation.CrossFade("Run", 0.1f);         //普通移動アニメーションを再生
//                speed = 12f;
//                if (ChargeAttack == true)
//                { 
//                    simpleAnimation.CrossFade("attack", 0.1f);
//                    Invoke("Chargeflg", 0.8f);
//                }
//            }
//        }
//        else if (inJumping == true) //ジャンプ中のとき
//        {
//            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
//            if (ChargeAttack == true)
//            {
//                simpleAnimation.CrossFade("attack", 0.1f);
//                Invoke("Chargeflg", 0.8f);
//            }
//        }
//        else
//        {
//            if (ChargeAttack == true)
//            { 
//                simpleAnimation.CrossFade("attack", 0.1f);
//                Invoke("Chargeflg", 0.8f);
//            }
//            else
//            {
//                simpleAnimation.Play("Default");        //デフォルトアニメーションを再生
//            }
//        }
//    }
//    ////地面との判定
//    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
//    {
//        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
//        {
//            Ground = true;//  Groundedをtrueにする
//            inJumping = false;
//        }
//    }
//    void Chargeflg()
//    {
//        ChargeAttack = false;
//    }
//}
//ボタン配置
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

    private float playerPosX;
    private float playerPosY;
    private float playerPosZ;
    private float playreRot;

    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;

    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力
    public float speed = 25f; //キャラクターの移動スピード

    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    //溜め攻撃の変数、フラグ
    bool ChargeAttack = false;
    int ChargeAttackCount;
    int ChargeTime = 60;  //溜め時間

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
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0);

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

        //溜め攻撃
        if (Input.GetButtonUp("B"))
        {
            //押している時間が ChargeTime より多いとき
            if (ChargeTime <= ChargeAttackCount)
            {
                this.playerPosX = transform.position.x;　　//座標を取得
                this.playerPosY = transform.position.y;　　//座標を取得
                this.playerPosZ = transform.position.z;　　//座標を取得
                this.playreRot = transform.rotation.y;
                ChargeAttackCount = 0;
                ChargeAttack = true;
            }
        }
        if (Input.GetButton("B"))
        {
            ChargeAttackCount++;
        }
        else
        {
            ChargeAttackCount = 0;
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
                //ジャンプしながら溜め攻撃でアタック
                if (ChargeAttack == true)
                {
                    AttackMove();
                    simpleAnimation.CrossFade("attack", 0.1f);
                    Invoke("Chargeflg", 0.8f);
                }
            }
            else
            {
                simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
                //ダッシュしながら溜め攻撃でアタック
                if (ChargeAttack == true)
                {
                    AttackMove();
                    simpleAnimation.CrossFade("attack", 0.1f);
                    Invoke("Chargeflg", 0.8f);
                }
            }
        }
        //アニメーションの再生(止まっている時)
        else if (inJumping == true) //ジャンプしたとき
        {
            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
            //ジャンプしながらBボタンでアタック
            if (ChargeAttack == true)
            {
                AttackMove();
                simpleAnimation.CrossFade("attack", 0.1f);
                Invoke("Chargeflg", 0.8f);
            }
        }
        else
        //Bボタンでアタック
        if (ChargeAttack == true)
        {
            AttackMove();
            simpleAnimation.CrossFade("attack", 0.1f);
            Invoke("Chargeflg", 0.8f);
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

    //溜め攻撃フラグ
    void Chargeflg()
    {
        ChargeAttack = false;
    }

    void AttackMove()  //攻撃した時の移動
    {
        if (0<playreRot)
        {
            rb.velocity = new Vector3(120, 0, 0);  //移動スピード
            if (transform.position.x < playerPosX + 15)   //ボタンを離した時の座標より10以上進んでいたらスピードをなくす
            {
                rb.velocity = new Vector3(0, 0, 0);       
            }
        }
        if(0 > playreRot)
        {
            
            rb.velocity = new Vector3(-120, 0, 0);  //移動スピード
            if (transform.position.x < playerPosX - 15)   //ボタンを離した時の座標より10以上進んでいたらスピードをなくす
            {
                rb.velocity = new Vector3(0, 0, 0);

            }
        }


    }
    
}