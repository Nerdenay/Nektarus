using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreditFadeOut : MonoBehaviour
{
    public Image[] images; // Fade i�lemi yap�lacak resimler
    public float fadeDuration = 1f; // Bir resmin fade i�lemi s�resi
    public float delayBetweenFades = 1f; // Resimler aras�ndaki gecikme s�resi

    private void Start()
    {
        // Ba�lang��ta t�m resimlerin alfa de�erini 0 yap
        foreach (var image in images)
        {
            Color color = image.color;
            color.a = 0;
            image.color = color;
        }

        // Fade i�lemini ba�lat
        StartCoroutine(FadeImages());
    }

    private IEnumerator FadeImages()
    {
        foreach (var image in images)
        {
            // Fade-in i�lemini ger�ekle�tir
            image.DOFade(1, fadeDuration);
            // Fade i�lemi tamamlanana kadar bekle
            yield return new WaitForSeconds(fadeDuration + delayBetweenFades);
        }
    }
}
