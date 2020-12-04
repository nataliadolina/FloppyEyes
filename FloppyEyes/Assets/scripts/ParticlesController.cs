using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    // Start is called before the first frame update 
    void Update()
    {
        
    }
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    public void PlayParticles()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ParticleSystem ps = child.GetComponent<ParticleSystem>();
            ps.Play();
        }
    }
    public void StopParticles()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ParticleSystem ps = child.GetComponent<ParticleSystem>();
            ps.Stop();
        }
    }
}
