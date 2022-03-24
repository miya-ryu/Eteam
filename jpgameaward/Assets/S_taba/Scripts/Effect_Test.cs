using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Test : MonoBehaviour
{
    private GameObject gb;
    private ParticleSystem ps;
 

    public bool PsFlag;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule emission = ps.emission;
        PsFlag = false;
        emission.enabled = PsFlag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!PsFlag)
            {
                ParticleSystem.EmissionModule emission = ps.emission;
                PsFlag = true;
                emission.enabled = PsFlag;
            }
            if (PsFlag)
            {
                ParticleSystem.EmissionModule emission = ps.emission;
                PsFlag = false;
                emission.enabled = PsFlag;
            }
        }
    }

    void Effect_test()
    {
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    if (!PsFlag)
        //    {
        //        ParticleSystem.EmissionModule emission = ps.emission;
        //        PsFlag = true;
        //        emission.enabled = PsFlag;
        //    }
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        ParticleSystem.EmissionModule emission = ps.emission;
        PsFlag = true;
        emission.enabled = PsFlag;
    }
}
