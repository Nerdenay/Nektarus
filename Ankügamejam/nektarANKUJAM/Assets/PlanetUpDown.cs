using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ImageAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image; // Animasyon yapmak istedi�in Image bile�enini buraya s�r�kle.
    public float moveDistance = 1f; // Hareket mesafesi
    public float animationDuration = 2f; // Animasyon s�resi (2 saniye �rne�i)
    public float scaleAmount = 1.5f; // B�y�me oran�
    public float scaleDuration = 0.3f; // B�y�me s�resi

    private Vector3 originalScale;

    void Start()
    {
        originalScale = image.rectTransform.localScale;

        // Yukar� ve a�a�� do�ru yumu�ak hareket et
        image.rectTransform.DOMoveY(image.rectTransform.position.y + moveDistance, animationDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Image b�y�t
        image.rectTransform.DOScale(originalScale * scaleAmount, scaleDuration).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Image orijinal boyuta d�nd�r
        image.rectTransform.DOScale(originalScale, scaleDuration).SetEase(Ease.OutBack);
    }
}
