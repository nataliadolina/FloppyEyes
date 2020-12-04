using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestScore : MonoBehaviour
{
    Text content;
    string score;
    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
        }
        score = PlayerPrefs.GetFloat("BestScore").ToString();
        content.text = score;
    }
}
