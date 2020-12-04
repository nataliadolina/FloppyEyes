using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage : MonoBehaviour
{
    [SerializeField]
    float waitTime = 0.5f;
    public GameObject manager;
    private GetAudioSource audios;
    private void Start()
    {
        audios = manager.GetComponent<GetAudioSource>();
    }
    public void LoadLevel()
    {
        audios.source.Play();
        StartCoroutine(Wait());
    }
    public void PlaySound()
    {
        audios.source.Play();
    }
    public void ByeBye()
    {
        Application.Quit();
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("SampleScene");
    }
}
