using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShockwave2_Effect : MonoBehaviour
{
    [SerializeField]
    //　パーティクルシステム
    private ParticleSystem ps;

    private bool flag;
    //　経過時間
    private float elapsedTime;

    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.GetComponent<Renderer>().enabled = false;
        //　MaxParticlesを超えるパーティクルを生成するまでシミュレーションスピードを上げる
        var main = ps.main;
        main.simulationSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;

        //　現在のパーティクル数がMaxParticlesを超えたらパーティクルを移動させる
        if (!flag && ps.particleCount >= ps.main.maxParticles)
        {
            var main = ps.main;
            main.simulationSpeed = 1f;
            flag = true;
            ps.GetComponent<Renderer>().enabled = true;
            var a = ps.velocityOverLifetime;
            a.radial = 2f;
        }
    }

    public void OnParticleTrigger()
    {

        if (ps != null && flag)
        {

            // particles
            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
            List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

            // get
            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

            if (numEnter != 0 || numInside != 0)
            {
                Debug.Log("接触");
            }

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enter[i];
                p.startColor = new Color32(255, 0, 0, 255);
                enter[i] = p;
            }

            for (int i = 0; i < numInside; i++)
            {
                ParticleSystem.Particle p = inside[i];
                p.startColor = new Color32(255, 0, 0, 255);
                inside[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        }
    }
}
