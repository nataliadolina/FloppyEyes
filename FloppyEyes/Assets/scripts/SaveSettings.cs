using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    static private Dictionary<bool, int> loseFlag;

    private void Start()
    {
        loseFlag = new Dictionary<bool, int>()
        {
            { true, 1},
            { false, 0}
        };
    }

    private static void SaveScore()
    {
        PlayerPrefs.SetFloat("Score", ShowScore.score);
        if (!PlayerPrefs.HasKey("BestScore") | PlayerPrefs.GetFloat("BestScore") == 0f)
        {
            PlayerPrefs.SetFloat("BestScore", ShowScore.score);
        }
        else if (ShowScore.score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", ShowScore.score);
        }
    }

    private static void SaveSpeed(float value)
    {
        PlayerPrefs.SetFloat("Speed", value);
    }

    public static void Save(bool lose = true)
    {
        SaveScore();
        if (lose)
        {
            PlayerPrefs.SetString("hasLost", "+");
            SaveSpeed(WorldController.initial_speed);
        }

        if (!lose)
        {
            PlayerPrefs.SetString("hasLost", "-");
            SaveSpeed(WorldController.CurrentSpeed);
        }         
    }
}
