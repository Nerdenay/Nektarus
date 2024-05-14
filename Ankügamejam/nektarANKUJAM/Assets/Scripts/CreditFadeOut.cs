using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreditFadeOut : MonoBehaviour
{
    public Image[] images; // Fade iþlemi yapýlacak resimler
    public float fadeDuration = 1f; // Bir resmin fade iþlemi süresi
    public float delayBetweenFades = 1f; // Resimler arasýndaki gecikme süresi

    private void Start()
    {
        // Baþlangýçta tüm resimlerin alfa deðerini 0 yap
        foreach (var image in images)
        {
            Color color = image.color;
            color.a = 0;
            image.color = color;
        }

        // Fade iþlemini baþlat
        StartCoroutine(FadeImages());
    }

    private IEnumerator FadeImages()
    {
        foreach (var image in images)
        {
            // Fade-in iþlemini gerçekleþtir
            image.DOFade(1, fadeDuration);
            // Fade iþlemi tamamlanana kadar bekle
            yield return new WaitForSeconds(fadeDuration + delayBetweenFades);
        }
    }
}
