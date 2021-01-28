using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public Image imPause;
    public Sprite pic_p1;
    public Sprite pic_p2;

    public Image imVolume;
    public Sprite pic_v1;
    public Sprite pic_v2;
    public AudioSource source;
    public void Start()
    {
        imPause.sprite = pic_p1;
        imVolume.sprite = pic_v1;
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            imPause.sprite = pic_p2;
        }
        else
        {
            Time.timeScale = 1;
            imPause.sprite = pic_p1;
        }
    }
    public void Music()
    {
        if (imVolume.sprite == pic_v1)
        {
            imVolume.sprite = pic_v2;
            if (source!=null)
                source.Pause();
        }
        else
        {
            imVolume.sprite = pic_v1;
            if (source != null)
                source.Play();
        }
    }
    public void Restart()
    {
        YunaController.instance.SaveSettings();
        SceneManager.LoadScene("SampleScene");
    }
    public void GetBackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Score", ShowScore.score);
        if (ShowScore.score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", ShowScore.score);
        }
        PlayerPrefs.SetFloat("Speed", WorldController.CurrentSpeed);
    }
}
