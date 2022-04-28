using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skeleton : MonoBehaviour
{
    float count;  

    //Oni のコライダーを取得
    public CapsuleCollider Ccol;

    Vector3 playerPos; //プレイヤーの位置
    GameObject player; //プレイヤー
    float distance;    //プレイヤーとの距離

    //範囲を視認できるワイヤーフレーム
    [SerializeField] float attackRange = 17f;
    [SerializeField] float attackRange2 = 6f;
    [SerializeField] float quitRange = 30f;
    [SerializeField] bool tracking = false;
    [SerializeField] bool attack = false;
    [SerializeField] bool attack2 = false;

    //パーティクル
    [SerializeField] private ParticleSystem particle = null;
    //DG.Tweening
    [SerializeField] private Renderer _renderer;
    private Sequence _seq;

    //Oniの体力
    private float Oni_hp = 3;

    // 使用する Animator をアタッチ
    [SerializeField] Animator anim;

    //ゲームクリア画面表示
    [SerializeField] GameObject GameClear_flg;

    //SoundScript の BosEnemy 関数を取得
    public SoundScript BosEnemyClip;

    void Start()
    {
        count = 4f;　　　//最初は条件をクリアできるように

        Ccollider();

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");

        anim.SetBool("Walk", true);
    }

    //Oniの無敵解除
    void Ccollider()
    {
        Ccol.enabled = true;
    }

    void Update()
    {
        count += Time.deltaTime;　//カウント

        //Oniの無敵時間が切れて2秒後に無敵解除
        if (Ccol.enabled == false)
        {
            Invoke(nameof(Ccollider), 2.0f);
        }
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);

        if (tracking)
        {
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
            {
                tracking = false;
            }
        }
        else
        {

        }

        if (attack)
        {
            //PlayerがattackRangeより距離が離れたら攻撃中止
            if (distance > attackRange)
            {
                attack = false;
                anim.SetBool("Attack1", false);
            }
        }
        else
        {
            //PlayerがattackRangeより近づいたら攻撃開始
            if (distance < attackRange)
            {
                attack = true;
                anim.SetBool("Attack1", true);
            }
        }

        if (attack2)
        {
            if(distance < attackRange2)
            {
                attack = false;
                attack2 = true;
                anim.SetBool("Attack1", false);
                anim.SetBool("Attack2", true);
            } 
        }
    }

    void OnDrawGizmosSelected()
    {
        //attackRangeの範囲を緑のワイヤーフレームで示す
        //緑のワイヤー外に出ると攻撃をやめる
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        //attackRange2の範囲を黄色のワイヤーフレームで示す
        //黄色のワイヤー外に出ると通常攻撃になる
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange2);

        //quitRangeの範囲を青いワイヤーフレームで示す
        //青のワイヤー外に出ると追跡をやめる
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Oniが無敵じゃない時
        if(Ccol.enabled == true)
        {
            // katana タグの付いたゲームオブジェクトと衝突したら
            if (other.gameObject.tag == "KATANA")
            {
                if (count > 2)　//カウントが以上の時ダメージを受ける
                {
                    count = 0;  //カウントリセット
                    Oni_hp--;            //OniのHPを1減らす
                    BosEnemyClip.BosEnemy();
                    Damage();             //ダメージ処理
                    Ccol.enabled = false; //無敵になる
                }
            }
        }
    }

    void Damage()
    {
        if(Oni_hp == 2 || Oni_hp == 1)
        {
            HitBlink();
        }
        if (Oni_hp == 0)
        {
            anim.SetBool("Dead", true);

            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;

            // パーティクルを発生させる。
            newParticle.Play();

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 4.0f);

            //このGameObjectを削除
            Destroy(this.gameObject, 0.8f);

            //ゲームクリアを表示させて5秒後にリザルト画面へ
            GameClear_flg.GetComponent<GameClear_flg>().enabled = true;
        }
    }

    private void HitBlink()
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => _renderer.enabled = false);
        _seq.AppendInterval(0.07f);
        _seq.AppendCallback(() => _renderer.enabled = true);
        _seq.AppendInterval(0.07f);
        _seq.SetLoops(2);
        _seq.Play();
    }
}