using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ImageAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image; // Animasyon yapmak istediðin Image bileþenini buraya sürükle.
    public float moveDistance = 1f; // Hareket mesafesi
    public float animationDuration = 2f; // Animasyon süresi (2 saniye örneði)
    public float scaleAmount = 1.5f; // Büyüme oraný
    public float scaleDuration = 0.3f; // Büyüme süresi

    private Vector3 originalScale;

    void Start()
    {
        originalScale = image.rectTransform.localScale;

        // Yukarý ve aþaðý doðru yumuþak hareket et
        image.rectTransform.DOMoveY(image.rectTransform.position.y + moveDistance, animationDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Image büyüt
        image.rectTransform.DOScale(originalScale * scaleAmount, scaleDuration).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Image orijinal boyuta döndür
        image.rectTransform.DOScale(originalScale, scaleDuration).SetEase(Ease.OutBack);
    }
}
