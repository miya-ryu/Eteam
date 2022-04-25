using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaifuku_Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem kakifuku_Effect;

    private void OnCollisionEnter(Collision collision)
    {
        //
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("回復した");
            //
            ParticleSystem newParticle = Instantiate(kakifuku_Effect);
            //
            newParticle.transform.position = this.transform.position;
            //
            newParticle.transform.parent = collision.gameObject.transform;
            //
            newParticle.Play();
        }
    }
}
