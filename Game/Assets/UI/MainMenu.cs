using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject controlsUI;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Controls()
    {
        mainMenuUI.SetActive(false);
        controlsUI.SetActive(true);
    }
    public void Back()
    {
        controlsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
