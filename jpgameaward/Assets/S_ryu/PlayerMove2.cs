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

public class PlayerMove2 : MonoBehaviour
{
    //突進攻撃
    private float playerPosX;
    private float playreRot;

    //重力
    [SerializeField] private Vector3 localGravity;
    // 地面に着地しているか判断するフラグ
    [SerializeField] private bool Ground;

    private Rigidbody rb;         // Rigidbodyを使うための変数
    public float Jumppower = 3000;       // ジャンプ力
    public float speed = 35f;     //キャラクターの移動スピード
    public float Jumpspeed = 17f; //ジャンプ中の移動スピード
    float dx;

    //溜め攻撃の変数、フラグ
    bool ChargeAttack = false;
    int ChargeAttackCount;
    int ChargeTime = 30;       //溜め時間

    //地面との接触判定
    private Ray ray;               //飛ばすレイ
    private float distance = 1.2f; //レイを飛ばす距離
    private RaycastHit rayhit;     //レイが当たった時の情報
    private Vector3 rayPosition;   //レイを発射する位置

    // 使用する Animator をアタッチ
    [SerializeField] Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyを代入

        rb.useGravity = false; //rigidbodyの重力を使わないようにする

        //キャラクターが回転してしまわないように回転方向を固定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    //重力
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
        //レイを発射する位置
        rayPosition = transform.position + new Vector3(0, 0.5f, 0);
        //レイを下に飛ばす
        ray = new Ray(rayPosition, Vector3.down);
        Ground = Physics.Raycast(ray, distance);
        //レイを赤色で表示させる
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        if(ChargeAttack == false)  //攻撃してない間だけ移動できる
        {
            dx = Input.GetAxis("Horizontal");
        }
        //横移動
        Vector3 pos = new Vector3(dx, 0);

        //Aボタンでジャンプ
        if (Input.GetButtonDown("A"))// Aボタンが押されたとき
        {
            if(Ground == true)
            {
                Ground = false;
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
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

            if (Ground == false) //ジャンプ中のとき
            {
                speed = Jumpspeed;
                //ジャンプアニメーションを再生
                anim.SetBool("jump", true);
                //ダッシュアニメーションを停止
                anim.SetBool("run", false);

                //ジャンプしながら溜め攻撃でアタック
                if (ChargeAttack == true)
                {
                    AttackMove();
                    //攻撃アニメーションを再生
                    anim.SetBool("attack", true);
                }
            }
            else
            {
                speed = 35f;
                if(Ground == true)
                {
                    //ダッシュアニメーションを再生
                    anim.SetBool("run", true);
                    //ジャンプアニメーションを停止
                    anim.SetBool("jump", false);

                    //ダッシュしながら溜め攻撃でアタック
                    if (ChargeAttack == true)
                    {
                        AttackMove();
                        //攻撃アニメーションを再生
                        anim.SetBool("attack", true);
                    }
                }
            }
        }
        //アニメーションの再生(止まっている時)
        else if (Ground == false) //ジャンプしたとき
        {
            speed = Jumpspeed;
            //ジャンプアニメーションを再生
            anim.SetBool("jump", true);
            //ダッシュアニメーションを停止
            anim.SetBool("run", false);

            //ジャンプしながらBボタンでアタック
            if (ChargeAttack == true)
            {
                AttackMove();
                //攻撃アニメーションを再生
                anim.SetBool("attack", true);
            }
        }
        //Bボタンでアタック
        else if (ChargeAttack == true)
        {
            AttackMove();
            //攻撃アニメーションを再生
            anim.SetBool("attack", true);
        }
        else
        {
            speed = 35f;
            //ダッシュアニメーションを停止
            anim.SetBool("run", false);
            //ジャンプアニメーションを停止
            anim.SetBool("jump", false);
            //攻撃アニメーションを停止
            anim.SetBool("attack", false);
        }
    }

    void attackmove0()
    {
        Chargeflg();
    }

    //溜め攻撃フラグ
    void Chargeflg()
    {
        ChargeAttack = false;
        rb.velocity = new Vector3(0, 0, 0);
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