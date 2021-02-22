using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public static float score;
    private static Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetFloat("Score");
        }
        else
            score = 0;
        text.text = score.ToString();
        text = GetComponent<Text>();
    }

    public static void ChangeScore()
    {
        score += 0.5f;
        text.text = score.ToString();
    }
}
