//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class test : MonoBehaviour
//{

//    [SerializeField]
//    player_test apManager;
//    [SerializeField]
//    Text recoveryTimeLabel;
//    [SerializeField]
//    Text apStatusLabel;
//    //[SerializeField]
//    //Transform hpBar;

//    void Start()
//    {
//        apManager.Init(100,100, System.DateTime.Now);  //体力、タイマー
//        apManager.UseActionPoint(10);      //-HP
//    }

//    void Update()
//    {
//        recoveryTimeLabel.text = apManager.GetRestRecoveryTimeLabel();      //回復インターバル表示
//        apStatusLabel.text = string.Format("{0:00}/{1:00}", apManager.point, apManager.maxPoint);   //HPラベル表示（数値）
//        //hpBar.localScale = new Vector3(apManager.ActionPointRatio(), 1, 1);     //HPバー表示
//    }

//}






////スタミナ
//const int Interval = 180;
//int Jnp_Hp = 100;       //ジャンプ体力
//public int point { get; private set; }      //現在のHP
//public int maxPoint = 100; /*{ get; private set; } */      //MaxHP
//double restRecoveryTime;
//DateTime lastRcoveryTime;      //最後に回復した時間

//public void Init(int point, int maxPoint, DateTime lastRcoveryTime)
//{
//    this.point = point;
//    this.maxPoint = maxPoint;
//    this.lastRcoveryTime = lastRcoveryTime;
//}

//public void RecoveryHP()        //ｈｐ回復
//{
//    point = maxPoint;
//}

//public string GetRestRecoveryTimeLabel()        //表示
//{
//    if (point >= maxPoint)
//    {
//        return "0:00";
//    }
//    var span = TimeSpan.FromSeconds(restRecoveryTime);
//    return string.Format("{0:00}:{1:00}", span.Minutes, span.Seconds);
//}

//public bool UseActionPoint(int usePoint)        //usePoint=10
//{

//    if (point <= usePoint)
//    {
//        return false;
//    }

//    if (point >= maxPoint)
//    {
//        lastRcoveryTime = DateTime.Now;
//    }

//    point -= usePoint;

//    return true;
//}

////public float ActionPointRatio()
////{
////    if (point >= maxPoint)
////    {
////        return 1f;
////    }

////    if (point == 0)
////    {
////        return 0f;
////    }

////    return (float)point / maxPoint;
////}

//void UpdateActionPointStatus()          //hpの更新処理
//{

//    if (point >= maxPoint)
//    {
//        return;
//    }

//    var time = DateTime.Now;
//    var diff = time - lastRcoveryTime;

//    var totalSeconds = diff.TotalSeconds;

//    while (totalSeconds > Interval)
//    {
//        if (point >= maxPoint)
//        {
//            break;
//        }

//        totalSeconds -= Interval;
//        lastRcoveryTime = lastRcoveryTime.Add(TimeSpan.FromSeconds(Interval));
//        point++;
//    }

//    restRecoveryTime = Interval - totalSeconds;
//}


