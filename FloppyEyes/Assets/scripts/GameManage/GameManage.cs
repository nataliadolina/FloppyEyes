using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    [SerializeField] private Image imPause;
    [SerializeField] private Sprite pic_p1;
    [SerializeField] private Sprite pic_p2;

    [SerializeField] private Image imVolume;
    [SerializeField] private Sprite pic_v1;
    [SerializeField] private Sprite pic_v2;

    private void Start()
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
            Debug.Log("Pause");
            imVolume.sprite = pic_v2;
            music.Pause();
        }
        else
        {
            Debug.Log("Continue");
            imVolume.sprite = pic_v1;
            music.Play();
        }
    }

    private IEnumerator WaitToRestart(float waitForSeconds)
    {
        yield return new WaitForSeconds(waitForSeconds);
        SaveSettings.Save();
        SceneManager.LoadScene("SampleScene");
    }

    public void Restart(float waitForSeconds=0f)
    {
        StartCoroutine(WaitToRestart(waitForSeconds)); 
    }

    public void GetBackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
        SaveSettings.Save(false);
    }
}
