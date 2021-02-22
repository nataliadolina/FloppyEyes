using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gem : MonoBehaviour
{
    [SerializeField] private GameObject sparkles;

    private AudioSource pickUpSound;
    private ParticleSystem[] particleSys;

    private void OnEnable()
    {
        particleSys = sparkles.GetComponentsInChildren<ParticleSystem>();
        pickUpSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var sys in particleSys)
            {
                sys.Play();
                sys.transform.parent = null;
            }
            pickUpSound.Play();
            Destroy(sparkles);
            Destroy(gameObject);
        }
    }

}
