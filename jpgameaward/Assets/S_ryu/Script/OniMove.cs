using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class OniMove : MonoBehaviour
{
    //Oni のコライダーを取得
    public CapsuleCollider Ccol;

    // NavMeshAgentコンポーネントを入れる変数
    private NavMeshAgent navMeshAgent;
    public Transform[] points; //歩くポイントを入れる変数
    private int destPoint = 0; //歩くポイントの数を指定する変数

    Vector3 playerPos; //プレイヤーの位置
    GameObject player; //プレイヤー
    float distance;    //プレイヤーとの距離

    //範囲を視認できるワイヤーフレーム
    [SerializeField] float trackingRange = 20f;
    [SerializeField] float attackRange = 17f;
    [SerializeField] float attackRange2 = 6f;
    [SerializeField] float quitRange = 30f;
    [SerializeField] bool tracking = false;
    [SerializeField] bool attack = false;

    //パーティクル
    [SerializeField] private ParticleSystem particle = null;
    //DG.Tweening
    [SerializeField] private Renderer _renderer;
    private Sequence _seq;

    //Oniの体力
    private float Oni_hp = 3;

    // 使用する Animator をアタッチ
    [SerializeField] Animator anim;

    void Start()
    {
        // NavMeshAgentを保持しておく
        navMeshAgent = GetComponent<NavMeshAgent>();

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");

        anim.SetBool("Walk", true);
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        navMeshAgent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {

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

            //Playerを目標とする
            navMeshAgent.destination = playerPos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
            {
                tracking = true;
            }

            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }

        if (attack)
        {
            //PlayerがtrackingRange2より距離が離れたら攻撃中止
            if (distance > attackRange)
            {
                attack = false;
                anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);
                anim.SetBool("Attack2", false);
            }
        }
        else
        {
            //PlayerがtrackingRange2より近づいたら攻撃開始
            if (distance < attackRange)
            {
                attack = true;
                anim.SetBool("Attack", true);
            }
            //PlayerがtrackingRange3より近づいたら攻撃開始
            if (attackRange < attackRange2)
            {
                Debug.Log("近づいた");
                attack = true;
                anim.SetBool("Attack2", true);
            }
        }

        //if (attack)
        //{
        //    //PlayerがtrackingRange3より距離が離れたら通常攻撃
        //    if (attackRange2 > attackRange)
        //    {
        //        attack = true;
        //        simpleAnimation.CrossFade("Attack", 0.1f);
        //    }
        //}
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        //赤のワイヤー内に入ると追跡する
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //trackingRange2の範囲を緑のワイヤーフレームで示す
        //緑のワイヤー外に出ると攻撃をやめる
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        //trackingRange3の範囲を黄色のワイヤーフレームで示す
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
        if(Ccol.enabled == true)
        {
            // katana タグの付いたゲームオブジェクトと衝突したら
            if (other.gameObject.tag == "KATANA")
            {
                Debug.Log("ヒット");
                Oni_hp--;
                HitBlink();
                Damage();
                Ccol.enabled = false;
            }
        }
        else
        {
            // katana タグの付いたゲームオブジェクトと衝突したら
            if (other.gameObject.tag == "KATANA")
            {
                Debug.Log("ヒット");
                Oni_hp--;
                HitBlink();
                Damage();
                Ccol.enabled = true;
            }
        }
    }

    void Damage()
    {
        if (Oni_hp == 2 || Oni_hp == 1)
        {
            //HitBlink();
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