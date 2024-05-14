using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu, planets;
    public Slider volumeSlider;
    public Animator transAnim;
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        Debug.Log(volumeSlider.value);
    }

    IEnumerator Play()
    {
        transAnim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
