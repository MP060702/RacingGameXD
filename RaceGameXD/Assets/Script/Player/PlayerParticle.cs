using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float raycastDistance = 2f;

    void Update()
    {
        RaycastHit hit;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance);

        if (isGrounded)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}
