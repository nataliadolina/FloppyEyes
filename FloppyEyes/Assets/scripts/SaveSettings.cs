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
    public static void Save(bool lose = true)
    {
        if (!PlayerPrefs.HasKey("hasLost"))
            PlayerPrefs.SetString("hasLost", "+");

        if (!lose)
            PlayerPrefs.DeleteKey("hasLost");

        PlayerPrefs.SetFloat("Score", ShowScore.score);
        if (ShowScore.score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", ShowScore.score);
        }

        if (!lose)
            PlayerPrefs.SetFloat("Speed", WorldController.CurrentSpeed);
    }
}
