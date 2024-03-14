using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public bool bIsParticle = true;
    public ParticleSystem Wheel_Particle;

    private void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;

        ParticleSystem.EmissionModule Emission;

        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {   
            bIsParticle = true;

            if (bIsParticle)
            {
                Emission = Wheel_Particle.emission;

                if (hit.distance > 3)
                {
                    Emission.rateOverTime = 0;
                }
            }
        }
        else
        {
            bIsParticle = false;
        }
    }
}
