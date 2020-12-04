using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    ParticleSystem ps;
    private bool israining;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Check(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Check(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int generate = Random.Range(0, 2);
        int time = Random.Range(5, 20);
        if (generate == 2 && !israining)
        {
            ps.Play();
            israining = true;
            yield return new WaitForSeconds(time);
            israining = false;
            ps.Stop();
        }
    }
}
