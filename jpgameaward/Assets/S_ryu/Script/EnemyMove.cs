using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    // NavMeshAgentコンポーネントを入れる変数
    private NavMeshAgent navMeshAgent;
    public Transform[] points;
    private int destPoint = 0;

    Vector3 playerPos;
    GameObject player;
    float distance;

    [SerializeField] float trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;

    void Start()
    {
        // NavMeshAgentを保持しておく
        navMeshAgent = GetComponent<NavMeshAgent>();

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
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
                tracking = false;

            //Playerを目標とする
            navMeshAgent.destination = playerPos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
                tracking = true;


            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        //赤のワイヤー内に入ると追跡する
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        //青のワイヤー外に出ると追跡をやめる
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}
