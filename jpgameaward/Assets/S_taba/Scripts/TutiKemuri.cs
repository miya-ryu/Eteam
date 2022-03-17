using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutiKemuri : MonoBehaviour
{
    //空中で土煙を出さない
    private ParticleSystem ps;
    public bool moduleEnabled;

    // Start is called before the first frame update
    void Start()
    {
        //空中でエフェクトを出さない
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule emission = ps.emission;
        moduleEnabled = false;
        emission.enabled = moduleEnabled;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!moduleEnabled)
            {
                ParticleSystem.EmissionModule emission = ps.emission;
                moduleEnabled = true;
                emission.enabled = moduleEnabled;
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            ParticleSystem.EmissionModule emission = ps.emission;
            moduleEnabled = false;
            emission.enabled = moduleEnabled;
        }
    }
}
