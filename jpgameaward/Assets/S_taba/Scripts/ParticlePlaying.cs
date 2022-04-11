using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlaying : MonoBehaviour
{
    private bool isPlaying;
    [SerializeField] ParticleSystem Chargeparticle;
    [SerializeField] ParticleSystem Circleparticle;
    [SerializeField] ParticleSystem ChargeShock1;
    [SerializeField] ParticleSystem ChargeShock2;

    public int cnt = 0;
    const int MAXCNT = 60;

    // Start is called before the first frame update
    void Start()
    {

        Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        ChargeShock1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        ChargeShock2.Stop(true, ParticleSystemStopBehavior.StopEmitting);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("B") || Input.GetKey("space"))
        {
            cnt++;
            //cnt %= MAXCNT;
            if(cnt == 120){
                ChargeShock1.Play(true);
                ChargeShock2.Play(true);

                ChargeShock1.gameObject.SetActive(true);
                ChargeShock2.gameObject.SetActive(true);

                if (ChargeShock1 == true)
                {
                    Invoke("ShockWaveStop", 0.1f);
                }
            }

            Chargeparticle.Play(true);
            Circleparticle.Play(true);
            //Invoke("ShockWave", 2f);
            //ChargeShock1.Play(true);
            //ChargeShock2.Play(true);

            Circleparticle.gameObject.SetActive(true);
            
        }
        else
        {
            cnt = 0;
            Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            ChargeShock1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            ChargeShock2.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            Circleparticle.gameObject.SetActive(false) ;
            ChargeShock1.gameObject.SetActive(false);
            ChargeShock2.gameObject.SetActive(false);

        }
    }
    void ShockWaveStop()
    {
        
        ChargeShock1.gameObject.SetActive(false);
        ChargeShock2.gameObject.SetActive(false);
    }
}
