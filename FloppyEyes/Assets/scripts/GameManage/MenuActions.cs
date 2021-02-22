using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    [SerializeField] private float waitTime = 0.5f;
    [SerializeField] private GameObject manager;

    private AudioSource click;

    private void Start()
    {
        click = manager.GetComponent<AudioSource>();
    }

    public void LoadLevel()
    {
        click.Play();
        StartCoroutine(Wait());
    }

    public void PlaySound()
    {
        click.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("SampleScene");
    }
}
