using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollisionParticles : MonoBehaviour
{
    public GameObject particles;
    Vector3 pos;
    private AudioSource source;
    private ParticlesController bum;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        bum = particles.GetComponent<ParticlesController>();
    }
    private void OnCollisionEnter(Collision coll)
    {   
        if (coll.collider.CompareTag("Player"))
        {
            source.Play();
            if (bum!= null)
            {
                foreach (ContactPoint contact in coll.contacts) /*проигрывает партиклы в точках столкновения*/
                {
                    pos = contact.point;
                    bum.SetPos(pos);
                    bum.PlayParticles();
                }
            }
            
            if (tag == "kill" | tag == "Ball")
            {
                YunaController.instance.PhysicKill();
            }
            else
            {
                if (!YunaController.instance.isJumping)
                {
                    YunaController.instance.PhysicKill();
                }
                else if (YunaController.instance.isJumping && !YunaController.instance.isClimbing)
                {
                    float delta = transform.localScale.y - coll.collider.transform.position.y + coll.collider.transform.localScale.y * 0.75f; /*считаем расстояние, на которое нужно взобраться*/
                    if (delta <= 5 && delta > 0.6)
                    {
                        tag = "-";
                        YunaController.instance.isJumping = false;
                        YunaController.instance.SetClimb(delta);
                    }
                    else if (delta <= 0.3) /*делаем препятсвтие безопасным*/
                    {
                        tag = "-";
                    }

                    else if (delta > 5) /*если слишком высоко, то игра заканчивается*/
                        YunaController.instance.PhysicKill();
                }
            }
        }
        
    }
}
