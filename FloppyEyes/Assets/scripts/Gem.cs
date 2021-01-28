using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gem : MonoBehaviour
{
    [SerializeField] private GameObject sparkles;

    private AudioSource audio;
    private ParticleSystem[] particleSys;

    private void OnEnable()
    {
        particleSys = sparkles.GetComponentsInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();
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

            Destroy(sparkles);
            Destroy(gameObject);
        }
    }

}
