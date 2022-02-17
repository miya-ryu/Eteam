using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    // Start is called before the first frame update

    //キャラクターの操作状態を管理するフラグ
    [SerializeField] public bool onGround = true;
    [SerializeField] public bool inJumping = false;

    //rigidbodyオブジェクト格納用変数
    Rigidbody rb;

    //移動速度の定義
    float speed = 6f;

    //ダッシュ速度の定義
    float sprintspeed = 9f;

    //方向転換速度の定義
    float angleSpeed = 200;

    //移動の係数格納用変数
    float v;
    float h;

    //SimpleAnimation変数
    SimpleAnimation simpleAnimation;

    void Start()
    {
        //キャラクターのrigidbodyの取得
        rb = this.GetComponent<Rigidbody>();

        //キャラクターが回転してしまわないように回転方向を固定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //キャラクターのSimpleAnimationを取得
        simpleAnimation = this.GetComponent<SimpleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shift+上下キーでダッシュ、上下キーで通常移動、それ以外は停止
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
            v = Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
            v = -Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.RightArrow))
            v = Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            v = -Time.deltaTime * speed;
        else
            v = 0;

        //移動の実行
        if(!inJumping)//空中での移動を禁止
        {
            transform.position += transform.forward * v;
        }

        //スペースボタンでジャンプする
        if(onGround)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                //ジャンプさせるため上方向に力を発生
                rb.AddForce(transform.up * 8, ForceMode.Impulse);
                //ジャンプ中は地面との接触判定をfalseにする
                onGround = false;
                inJumping = true;

                //前後キーを押しながらジャンプしたときは前後方向の力も発生
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(transform.forward * 6f, ForceMode.Impulse);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(transform.forward * -3f, ForceMode.Impulse);
                }
            }
        }

        //左右キーで方向転換
        //if (Input.GetKey(KeyCode.RightArrow))
        //    h = Time.deltaTime * angleSpeed;
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //    h = -Time.deltaTime * angleSpeed;
        //else
        //    h = 0;

        //方向転換動作の実行
        transform.Rotate(Vector3.up * h);

        //前後方向キーを押したとき
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            //ジャンプ中のとき
            if (inJumping)
            {
                //ジャンプアニメーションを再生
                simpleAnimation.CrossFade("Jump", 0.1f);
            }
            //ダッシュキー押下時
            else if (Input.GetKey(KeyCode.LeftShift))
                //ダッシュアニメーションを再生
                simpleAnimation.CrossFade("Sprint", 0.1f);
            else
            {
                //ジャンプ中
                if (inJumping)
                    //ジャンプアニメーションを再生
                    simpleAnimation.CrossFade("Jump", 0.1f);
                else
                    //移動アニメーションを再生
                    simpleAnimation.CrossFade("Run", 0.1f);
            }

        }
        //スペースキー押下時
        else if (Input.GetKey(KeyCode.Space))
        {
            //ジャンプアニメーションを再生
            simpleAnimation.CrossFade("Jump", 0.1f);
            inJumping = true;
        }
        else//それ以外
        {
            if (inJumping) { }//ジャンプ中はそのまま
            else//それ以外
            {
                //デフォルトアニメーションを再生
                simpleAnimation.Play("Default");
            }
        }

    }
    //地面に接触したときにはonGroundをtrue、injumpingをfalseにする
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
            inJumping = false;
            simpleAnimation.Stop("Jump");
            simpleAnimation.Play("Default");
        }
    }
}

