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

public class PlayerMove1 : MonoBehaviour
{
    public SOUNDS sounds;


    //突進攻撃
    private float playerPosX;
    private float playerPosY;
    private float playerPosZ;
    private float playreRot;

    //プレイヤーフラグ
    [SerializeField] public bool inJumping = false;
    //重力
    [SerializeField] private Vector3 localGravity;

    private Rigidbody rb; // Rigidbodyを使うための変数
    private bool Ground; // 地面に着地しているか判定する変数
    public float Jumppower; // ジャンプ力
    public float speed = 35f; //キャラクターの移動スピード
    public float Jumpspeed = 15f; //ジャンプ中の移動スピード

    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    //溜め攻撃の変数、フラグ
    bool ChargeAttack = false;
    int ChargeAttackCount;
    int ChargeTime = 30;  //溜め時間

    void Start()
    {

        rb = GetComponent<Rigidbody>();//  rbにRigidbodyを代入

        rb.useGravity = false; //rigidbodyの重力を使わないようにする

        //キャラクターが回転してしまわないように回転方向を固定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //キャラクターのSimpleAnimationを取得
        simpleAnimation = this.GetComponent<SimpleAnimation>();
    }

    private void FixedUpdate()
    {
        SetLocalGravity();
    }

    private void SetLocalGravity()
    {
        rb.AddForce(localGravity, ForceMode.Acceleration);
    }

    void Update()
    {
        //横移動
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0);

        //Aボタンでジャンプ
        if (Input.GetButtonDown("A"))//  もし、Aボタンがおされたなら、
        {
            if (Ground == true)//  もし、Groundedがtrueなら、
            {
                Ground = false;
                inJumping = true;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
                sounds.SE1(); //音(sound1)を鳴らす
            }
        }

        //溜め攻撃
        if (Input.GetButtonUp("B"))
        {
            //押している時間が ChargeTime より多いとき
            if(ChargeTime <= ChargeAttackCount)
            {
                //突進攻撃
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
                speed = Jumpspeed;
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
                speed = 35f;
                if(Ground == true)
                {
                    simpleAnimation.CrossFade("Sprint", 0.1f);      //ダッシュアニメーションを再生
                    //sounds.SE2();
                }
                //ダッシュしながら溜め攻撃でアタック
                if (ChargeAttack == true)
                {
                    AttackMove();
                    simpleAnimation.CrossFade("attack", 0.1f);
                    Invoke("Chargeflg", 0.8f);
                    sounds.SE3();//攻撃音を再生
                }
            }
        }
        //アニメーションの再生(止まっている時)
        else if (inJumping == true) //ジャンプしたとき
        {
            speed = Jumpspeed;
            simpleAnimation.CrossFade("Jump", 0.1f);        //ジャンプアニメーションを再生
            //ジャンプしながらBボタンでアタック
            if (ChargeAttack == true)
            {
                AttackMove();
                simpleAnimation.CrossFade("attack", 0.1f);
                Invoke("Chargeflg", 0.8f);
                sounds.SE4();//攻撃音を再生
            }
        }
        //Bボタンでアタック
        else if (ChargeAttack == true)
        {
            AttackMove();
            simpleAnimation.CrossFade("attack", 0.1f);
            Invoke("Chargeflg", 0.8f);
            sounds.SE5();//攻撃音を再生
        }
        else
        {
            speed = 35f;
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
            sounds.SE2();   //ダッシュ音を再生
        }
    }

    //溜め攻撃フラグ
    void Chargeflg()
    {
        ChargeAttack = false;
    }

    void AttackMove()  //攻撃した時の移動
    {
        if (0 < playreRot)
        {
            rb.velocity = new Vector3(120, 0, 0);  //移動スピード
            if (transform.position.x > playerPosX + 15)   //ボタンを離した時の座標より10以上進んでいたらスピードをなくす
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (0 > playreRot)
        {

            rb.velocity = new Vector3(-120, 0, 0);  //移動スピード
            if (transform.position.x < playerPosX - 15)   //ボタンを離した時の座標より10以上進んでいたらスピードをなくす
            {
                rb.velocity = new Vector3(0, 0, 0);

            }
        }
    }
}