using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandCleaned : MonoBehaviour
{
    public int currentScene;
    public Animator transAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentScene == 2)
        {
            if (collision.gameObject.CompareTag("Hitbox"))
            {
                StartCoroutine(T());
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(T());
            }
        }
    }

    IEnumerator T()
    {
        transAnim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        transAnim.SetBool("FadeOut", false);
        SceneManager.LoadScene(currentScene + 1);
    }
}
