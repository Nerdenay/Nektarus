using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class MainMenuAnimation : MonoBehaviour
{
    public Transform characterTransform; // Karakterin Transform bile�eni
    public RectTransform imageTransform; // Image'in RectTransform bile�eni
    public Vector2 characterTargetPosition; // Hedef konum
    public Vector2 targetPosition; // Hedef konum

    public RectTransform[] buttonTransforms; // Butonlar�n RectTransform bile�enleri

    public float imageDuration = 1f; // Image animasyon s�resi
    public float buttonDuration = 1f; // Buton animasyon s�resi
    public float delayBetweenButtons = 0.5f; // Butonlar aras� gecikme s�resi

    void Start()
    {
        AnimateImage();
        AnimateButtons();

        characterTransform.position = new Vector2(characterTargetPosition.x - 10f, characterTargetPosition.y);

        // Karakteri yava��a hedef konuma do�ru hareket ettir
        characterTransform.DOMove(characterTargetPosition, imageDuration)
            .SetEase(Ease.OutQuad); // Animasyon e�risi
    }

    void AnimateImage()
    {
        Vector2 originalPosition = imageTransform.anchoredPosition;

        // Image'i yukardan hedef konuma do�ru yava��a hareket ettir
        imageTransform.DOAnchorPos(targetPosition, imageDuration)
            .From(new Vector2(originalPosition.x, originalPosition.y + 1000f)) // Y�ksek bir ba�lang�� noktas�ndan ba�lat
            .SetEase(Ease.OutQuad); // Animasyon e�risi

        // Yukar�daki animasyonu daha yava� ve yava��a ba�latmak istiyorsan�z �u sat�ra ekleme yapabilirsiniz:
        //.SetDelay(1f) // 1 saniye gecikme
    }

    void AnimateButtons()
    {
        // Her bir buton i�in animasyonu olu�tur
        for (int i = 0; i < buttonTransforms.Length; i++)
        {
            // Butonun ba�lang�� konumunu sakla
            Vector2 originalPosition = buttonTransforms[i].anchoredPosition;

            // Butonu a�a��dan yukar�ya do�ru hareket ettir
            buttonTransforms[i].DOAnchorPos(originalPosition, buttonDuration)
                .From(new Vector2(originalPosition.x, originalPosition.y - 1000f)) // A�a��dan ba�lat
                .SetEase(Ease.OutQuad) // Animasyon e�risi
                .SetDelay(i * delayBetweenButtons); // Butonlar aras� gecikme
        }
    }

}
