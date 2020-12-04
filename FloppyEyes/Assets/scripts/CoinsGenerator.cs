using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public GameObject[] Coins;
    public Transform pos;
    public GameObject obj;
    public Transform prefabinstance;
    GameObject obj1;
    // Start is called before the first frame update
    void Start()
    {
        int generate = Random.Range(0, 2);
        int index = Random.Range(0, Coins.Length);
        if (generate == 1)
        {
            obj = Coins[index];
            Instantiate(obj, pos.position, Quaternion.identity, WorldBuilder.instance.platformContainer);
            GameObject obj1 = Instantiate(obj, pos.position, Quaternion.identity, WorldBuilder.instance.platformContainer);

        }
            
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
