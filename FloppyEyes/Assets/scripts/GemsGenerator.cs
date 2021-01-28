using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GemsGenerator : MonoBehaviour
{
    [SerializeField] private float appearGemProbability;
    public List<GameObject> gemModels;

    private float deleteLimit;
    private Transform[] gemContainers;
    private List<GameObject> generatedGems;

    private Transform parentPlatform;
    private System.Random rnd;

    private void OnEnable()
    {
        deleteLimit = GetComponentInParent<PlatformController>().newPlatformAppearLimit;
        gemContainers = GetComponentsInChildren<Transform>();
        rnd = new System.Random();

        parentPlatform = GetComponentInParent<PlatformController>().transform;
        generatedGems = new List<GameObject>();
        Generate();
    }
    
    private void Generate()
    {
        int quantity = Convert.ToInt16(gemContainers.Length * appearGemProbability);
        List<int> generated = new List<int>();

        for (int i = 0; i < quantity; i++)
        {
            int k = rnd.Next(0, gemContainers.Length);
            while (generated.Contains(k))
            {
                k = rnd.Next(0, gemContainers.Length);
            }

            int modelInd = rnd.Next(0, gemModels.Count);
            var container = gemContainers[k];
            var gem = Instantiate(gemModels[modelInd], container.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            gem.transform.parent = parentPlatform;
            generatedGems.Add(gem);
            generated.Add(k);
        }
    }

}
