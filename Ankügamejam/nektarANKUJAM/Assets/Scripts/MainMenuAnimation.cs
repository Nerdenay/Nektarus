using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class MainMenuAnimation : MonoBehaviour
{
    public Transform characterTransform; // Karakterin Transform bileþeni
    public RectTransform imageTransform; // Image'in RectTransform bileþeni
    public Vector2 characterTargetPosition; // Hedef konum
    public Vector2 targetPosition; // Hedef konum

    public RectTransform[] buttonTransforms; // Butonlarýn RectTransform bileþenleri

    public float imageDuration = 1f; // Image animasyon süresi
    public float buttonDuration = 1f; // Buton animasyon süresi
    public float delayBetweenButtons = 0.5f; // Butonlar arasý gecikme süresi

    void Start()
    {
        AnimateImage();
        AnimateButtons();

        characterTransform.position = new Vector2(characterTargetPosition.x - 10f, characterTargetPosition.y);

        // Karakteri yavaþça hedef konuma doðru hareket ettir
        characterTransform.DOMove(characterTargetPosition, imageDuration)
            .SetEase(Ease.OutQuad); // Animasyon eðrisi
    }

    void AnimateImage()
    {
        Vector2 originalPosition = imageTransform.anchoredPosition;

        // Image'i yukardan hedef konuma doðru yavaþça hareket ettir
        imageTransform.DOAnchorPos(targetPosition, imageDuration)
            .From(new Vector2(originalPosition.x, originalPosition.y + 1000f)) // Yüksek bir baþlangýç noktasýndan baþlat
            .SetEase(Ease.OutQuad); // Animasyon eðrisi

        // Yukarýdaki animasyonu daha yavaþ ve yavaþça baþlatmak istiyorsanýz þu satýra ekleme yapabilirsiniz:
        //.SetDelay(1f) // 1 saniye gecikme
    }

    void AnimateButtons()
    {
        // Her bir buton için animasyonu oluþtur
        for (int i = 0; i < buttonTransforms.Length; i++)
        {
            // Butonun baþlangýç konumunu sakla
            Vector2 originalPosition = buttonTransforms[i].anchoredPosition;

            // Butonu aþaðýdan yukarýya doðru hareket ettir
            buttonTransforms[i].DOAnchorPos(originalPosition, buttonDuration)
                .From(new Vector2(originalPosition.x, originalPosition.y - 1000f)) // Aþaðýdan baþlat
                .SetEase(Ease.OutQuad) // Animasyon eðrisi
                .SetDelay(i * delayBetweenButtons); // Butonlar arasý gecikme
        }
    }

}
