using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ScorePlace
{
    StartScreen,
    Game
}

public class ShowScore : MonoBehaviour
{
    [SerializeField] private ScorePlace place;
    public static float score;
    private float showScore;
    public static Text text;

    private void Start()
    {
        score = 0f;
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("Score"))
        {
            if (PlayerPrefs.HasKey("HasLost"))
            {
                if (PlayerPrefs.GetString("HasLost") == "-")
                {
                    score = PlayerPrefs.GetFloat("Score");
                    showScore = score;
                }
            }
            else if (place == ScorePlace.StartScreen)
                showScore = PlayerPrefs.GetFloat("Score");
            text.text = showScore.ToString();
        }
    }

    public static void ChangeScore()
    {
        score += 0.5f;
        text.text = score.ToString();
    }
}
