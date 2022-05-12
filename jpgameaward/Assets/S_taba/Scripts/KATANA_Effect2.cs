using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KATANA_Effect2 : MonoBehaviour
{
    TrailRenderer KATANA_TrailRenderer;
    //private TrailRenderer;
    public int cntTrail = 0;    //溜め時間を管理する変数
    const int MAXCNT = 60; //溜まりきる時間を格納する変数
    [SerializeField] public ParticleSystem Blood = null;
    // Start is called before the first frame update
    void Start()
    {
        KATANA_TrailRenderer = GetComponent<TrailRenderer>();
        KATANA_TrailRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("B") || Input.GetKey(KeyCode.Space))//Bボタンで長押しで溜めエフェクト
        {
            cntTrail++;
        }
        else
        {
            if (cntTrail >= 60)
            {
                KATANA_TrailRenderer.enabled = true;
                Invoke("Delete_Effect", 0.8f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //攻撃時に敵と衝突したら
        if (other.gameObject.tag == "Enemy")
        {
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem blood = Instantiate(Blood);
            blood.transform.position = this.transform.position;
            blood.Play();
        }
    }
    void Delete_Effect()
    {
        KATANA_TrailRenderer.enabled = false;
        cntTrail = 0;
    }
}
