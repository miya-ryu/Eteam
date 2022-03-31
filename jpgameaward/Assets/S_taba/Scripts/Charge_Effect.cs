using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Effect : MonoBehaviour
{
    ParticleSystem PS_Charge;
    private ParticleSystem.Particle[] PS_Particle;
    float PS_TotalTime = 0;
    public float PS_Speed = 1;
    Vector3 tmp;
    // Start is called before the first frame update
    void Start()
    {
        PS_Charge = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
