using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    private void OnEnable()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void PlayParticles()
    {
        foreach (var sys in particleSystems)
        {
            sys.Play();
        }
    }
    public void StopParticles()
    {
        foreach (var sys in particleSystems)
        {
            sys.Stop();
        }
    }
}
