using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlaying : MonoBehaviour
{
    private bool isPlaying;
    [SerializeField] ParticleSystem Chargeparticle;
    [SerializeField] ParticleSystem Circleparticle;

    // Start is called before the first frame update
    void Start()
    {

        Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        //Invoke("DestroyParticle", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("B") || Input.GetKey("space"))
        {
            Chargeparticle.Play(true);
            Circleparticle.Play(true);

            Circleparticle.gameObject.SetActive(true);
        }
        else
        {
            Chargeparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Circleparticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            Circleparticle.gameObject.SetActive(false) ;

        }
    }
    //void DestroyParticle()
    //{
    //    Destroy(Circleparticle);
    //}

    //public void Switch()
    //{
    //    if (isPlaying)
    //    {
    //        particle.Play(true);
    //    }
    //    else
    //    {
    //        particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    //    }
    //    isPlaying = !isPlaying;
    //}
}
