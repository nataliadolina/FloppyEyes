using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForBall : MonoBehaviour
{
    private Rigidbody rb;
    public float force1;
    public float force2;
    private float k = 0;
    public GameObject targetingGreen;
    public GameObject targetingRed;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var builder = FindObjectOfType<WorldBuilder>();

        // target = Instantiate(targetingGreen, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), builder.currentPlatform.transform);
        rb.AddForce(Vector3.up * Random.Range(force1, force2));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 3.5f)
        {
            Destroy(target.gameObject);
            //target = Instantiate(targetingRed, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), WorldBuilder.instance.currentPlatform.transform);
        }
        else if (transform.position.y > 3.5f)
        {
            Destroy(target.gameObject);
            //target = Instantiate(targetingGreen, new Vector3(transform.position.x, 0.4f, transform.position.z), Quaternion.Euler(90, 0, 0), WorldBuilder.instance.currentPlatform.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (k >= 1)
        {
            if (rb != null)
            {
                rb.AddForce(Vector3.up * Random.Range(force1, force2));
                k = 0;
            }
        }
        else
            k++;
    }
}
