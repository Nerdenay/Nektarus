using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator transAnim;
    public string sceneName;
    public void EnterPlanet()
    {
        AudioManager.Instance.PlaySFX("transation");
    }

    public void Transition()
    {
        StartCoroutine(T());
    }

    IEnumerator T()
    {
        transAnim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        transAnim.SetBool("FadeOut", false);
        SceneManager.LoadScene(sceneName);
    }

}
