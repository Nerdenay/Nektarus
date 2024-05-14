using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneStart : MonoBehaviour
{
    [SerializeField]
    private List<Image> images; // Inspector'dan ayarlanabilir image listesi

    [SerializeField]
    private Image splitImage1; // �kinci s�radaki ilk g�r�nt�
    [SerializeField]
    private Image splitImage2; // �kinci s�radaki ikinci g�r�nt�

    [SerializeField]
    private TextMeshProUGUI endText; // Sona eklenecek yaz�

    public float fadeDuration = 1f; // Fade in ve fade out s�resi
    public float displayDuration = 2f; // G�r�nme s�resi

    public Animator transAnim;

    private IEnumerator Start()
    {
        // B�t�n image'lar� ve yaz�y� tamamen �effaf yap
        foreach (Image img in images)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        }

        splitImage1.color = new Color(splitImage1.color.r, splitImage1.color.g, splitImage1.color.b, 0);
        splitImage2.color = new Color(splitImage2.color.r, splitImage2.color.g, splitImage2.color.b, 0);

        endText.color = new Color(endText.color.r, endText.color.g, endText.color.b, 0);

        yield return new WaitForSeconds(1);
        StartCoroutine(FadeImagesSequentially());
    }

    private IEnumerator FadeImagesSequentially()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (i == 1) // �kinci s�radaki splitImage'lar
            {
                StartCoroutine(FadeSplitImages());
                yield return new WaitForSeconds(fadeDuration + displayDuration);
            }
            else if (i == 2) // ���nc� s�radaki image i�in
            {
                // Fade in
                images[i].DOFade(1, fadeDuration);
                yield return new WaitForSeconds(fadeDuration);

                // Sert sallanma
                images[i].rectTransform.DOShakePosition(4f, new Vector3(10f, 0, 0), 20, 90, false, true);
                yield return new WaitForSeconds(displayDuration);

                // Fade out
                images[i].DOFade(0, fadeDuration);
                yield return new WaitForSeconds(fadeDuration);
            }
            else
            {
                // Fade in
                images[i].DOFade(1, fadeDuration);
                yield return new WaitForSeconds(fadeDuration + displayDuration);

                // Fade out
                images[i].DOFade(0, fadeDuration);
                yield return new WaitForSeconds(fadeDuration);
            }
        }
        yield return StartCoroutine(ShowEndText());
    }

    private IEnumerator FadeSplitImages()
    {
        // Fade in her iki image
        splitImage1.DOFade(1, fadeDuration);
        splitImage2.DOFade(1, fadeDuration);

        // splitImage2'yi sa�a do�ru kayd�r
        splitImage2.transform.DOLocalMoveX(splitImage2.transform.localPosition.x + 50f, fadeDuration);

        yield return new WaitForSeconds(fadeDuration + displayDuration);

        // Fade out her iki image
        splitImage1.DOFade(0, fadeDuration);
        splitImage2.DOFade(0, fadeDuration);

        yield return new WaitForSeconds(fadeDuration);
    }

    private IEnumerator ShowEndText()
    {
        // Yaz�y� fade in yap
        endText.DOFade(1, fadeDuration);
        yield return new WaitForSeconds(displayDuration);

        // Yaz�y� fade out yap
        endText.DOFade(0, fadeDuration);
        yield return new WaitForSeconds(fadeDuration);

        StartCoroutine(T());
    }

    private IEnumerator T()
    {
        transAnim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        transAnim.SetBool("FadeOut", false);
        SceneManager.LoadScene("PlanetChoosing");
    }
}
