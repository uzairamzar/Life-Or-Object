using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition; // To store the original position of the object

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition; // Store the original position
        canvasGroup.alpha = 0.6f; // Make it transparent
        canvasGroup.blocksRaycasts = false; // Allow drop zones to detect the object
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Move with mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restore visibility
        canvasGroup.blocksRaycasts = true; // Enable raycast detection
    }

    public void ReturnToStartPosition()
    {
        rectTransform.anchoredPosition = originalPosition; // Move back to the original position
    }
}
