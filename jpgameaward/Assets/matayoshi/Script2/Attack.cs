using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody rb; // Rigidbodyを使うための変数

    private float playerPosX;
    private float playerPosY;
    private float playerPosZ;
    private float playreRot;

    public float speed = 35f; //キャラクターの移動スピード

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

        //StartCoroutine("ChargeAttack1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("B"))
        {
            //押している時間が ChargeTime より多いとき
            if (ChargeTime <= ChargeAttackCount)
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

        if(ChargeAttack == true)
        {
            AttackMove();
            simpleAnimation.CrossFade("attack", 0.1f);
            Invoke("Chargeflg", 0.8f);
            //CancelInvoke();
        }
        else
        {
            speed = 35f;
            simpleAnimation.Play("Default");        //デフォルトアニメーションを再生
        }
    }
    //IEnumerator ChargeAttack1()
    //{

    //}

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
