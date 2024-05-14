using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AxolotScript : MonoBehaviour
{
    public RectTransform imageTransform1; // Ýlk Image'in RectTransform bileþeni
    public RectTransform imageTransform2; // Ýkinci Image'in RectTransform bileþeni

    public Image bitkicerceve;
    public Image bitki;

    [SerializeField]
    private TextMeshProUGUI infotext; // Text bileþeni, Inspector'dan eriþilebilir

    [SerializeField]
    private string infoTextContent; // Inspector'dan ayarlanabilir metin

    [SerializeField]
    private Sprite bitkiSprite; // Inspector'dan ayarlanabilir sprite

    public Vector2 targetPosition1; // Ýlk Image'in hedef konumu
    public Vector2 targetPosition2; // Ýkinci Image'in hedef konumu

    public float imageDuration = 1f; // Image animasyon süresi
    public float waitTimeBeforeExit = 4f; // Animasyonlar tamamlandýktan sonra bekleme süresi
    public float exitDuration = 1f; // Sahneden çýkýþ süresi

    void Start()
    {
        // Inspector'dan alýnan metni infotext bileþenine ata
        infotext.text = infoTextContent;

        // Sprite'ý bitki Image'ine ata
        bitki.sprite = bitkiSprite;

        AnimateImage(imageTransform1, targetPosition1);
        AnimateImage(imageTransform2, targetPosition2);
    }

    void AnimateImage(RectTransform imageTransform, Vector2 targetPosition)
    {
        Vector2 originalPosition = imageTransform.anchoredPosition;

        // Image'i yukardan hedef konuma doðru yavaþça hareket ettir
        imageTransform.DOAnchorPos(targetPosition, imageDuration)
            .From(new Vector2(originalPosition.x, originalPosition.y + 1000f)) // Yüksek bir baþlangýç noktasýndan baþlat
            .SetEase(Ease.OutQuad) // Animasyon eðrisi
            .OnComplete(() => StartCoroutine(ExitAfterDelay(imageTransform, targetPosition))); // Tamamlandýktan sonra çýkýþ animasyonunu baþlat
    }

    IEnumerator ExitAfterDelay(RectTransform imageTransform, Vector2 targetPosition)
    {
        yield return new WaitForSeconds(waitTimeBeforeExit); // Bekleme süresi

        // Image'i sahneden yukarý doðru hareket ettir
        imageTransform.DOAnchorPos(new Vector2(targetPosition.x, targetPosition.y + 1000f), exitDuration)
            .SetEase(Ease.InQuad); // Çýkýþ animasyon eðrisi
    }
}
