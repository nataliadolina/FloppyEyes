using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject particles;
    private AudioSource source;
    private ParticlesController sparkles;
    private void Awake()
    {
        
        //DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        source = StaticSound.source;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            sparkles = child.GetComponent<ParticlesController>();
        }
        WorldController.instance.DeleteGem += DestroyGem;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowScore.ChangeScore();
            sparkles.PlayParticles();
            if (source!=null)
                source.Play();
            particles.transform.parent = WorldBuilder.instance.currentPlatform.transform;
            Destroy(gameObject);
        }
    }

    public void DestroyGem()
    {
        if (transform.position.z <= -5)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        WorldController.instance.DeleteGem -= DestroyGem;
    }
}
