using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestScore : MonoBehaviour
{
    private Text content;

    void Start()
    {
        content = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
        }
        string score = PlayerPrefs.GetFloat("BestScore").ToString();
        content.text = score;
    }
}
