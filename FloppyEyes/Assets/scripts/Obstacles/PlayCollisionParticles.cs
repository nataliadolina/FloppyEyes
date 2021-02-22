using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollisionParticles : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    private Vector3 pos;
    private AudioSource source;
    private ParticlesController particlesHandler;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        particlesHandler = particles.GetComponent<ParticlesController>();
    }
    private void OnCollisionEnter(Collision coll)
    {   
        if (coll.collider.CompareTag("Player"))
        {
            source.Play();
            if (particlesHandler != null)
            {
                foreach (ContactPoint contact in coll.contacts) /*проигрывает партиклы в точках столкновения*/
                {
                    pos = contact.point;
                    particlesHandler.SetPos(pos);
                    particlesHandler.PlayParticles();
                }
            }
        }
        
    }
}
