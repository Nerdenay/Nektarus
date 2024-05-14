using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AxolotScript : MonoBehaviour
{
    public RectTransform imageTransform1; // �lk Image'in RectTransform bile�eni
    public RectTransform imageTransform2; // �kinci Image'in RectTransform bile�eni

    public Image bitkicerceve;
    public Image bitki;

    [SerializeField]
    private TextMeshProUGUI infotext; // Text bile�eni, Inspector'dan eri�ilebilir

    [SerializeField]
    private string infoTextContent; // Inspector'dan ayarlanabilir metin

    [SerializeField]
    private Sprite bitkiSprite; // Inspector'dan ayarlanabilir sprite

    public Vector2 targetPosition1; // �lk Image'in hedef konumu
    public Vector2 targetPosition2; // �kinci Image'in hedef konumu

    public float imageDuration = 1f; // Image animasyon s�resi
    public float waitTimeBeforeExit = 4f; // Animasyonlar tamamland�ktan sonra bekleme s�resi
    public float exitDuration = 1f; // Sahneden ��k�� s�resi

    void Start()
    {
        // Inspector'dan al�nan metni infotext bile�enine ata
        infotext.text = infoTextContent;

        // Sprite'� bitki Image'ine ata
        bitki.sprite = bitkiSprite;

        AnimateImage(imageTransform1, targetPosition1);
        AnimateImage(imageTransform2, targetPosition2);
    }

    void AnimateImage(RectTransform imageTransform, Vector2 targetPosition)
    {
        Vector2 originalPosition = imageTransform.anchoredPosition;

        // Image'i yukardan hedef konuma do�ru yava��a hareket ettir
        imageTransform.DOAnchorPos(targetPosition, imageDuration)
            .From(new Vector2(originalPosition.x, originalPosition.y + 1000f)) // Y�ksek bir ba�lang�� noktas�ndan ba�lat
            .SetEase(Ease.OutQuad) // Animasyon e�risi
            .OnComplete(() => StartCoroutine(ExitAfterDelay(imageTransform, targetPosition))); // Tamamland�ktan sonra ��k�� animasyonunu ba�lat
    }

    IEnumerator ExitAfterDelay(RectTransform imageTransform, Vector2 targetPosition)
    {
        yield return new WaitForSeconds(waitTimeBeforeExit); // Bekleme s�resi

        // Image'i sahneden yukar� do�ru hareket ettir
        imageTransform.DOAnchorPos(new Vector2(targetPosition.x, targetPosition.y + 1000f), exitDuration)
            .SetEase(Ease.InQuad); // ��k�� animasyon e�risi
    }
}
