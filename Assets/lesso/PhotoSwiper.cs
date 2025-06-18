using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhotoSwiper : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image photoDisplay; // UI Image to display the photos
    public Sprite[] photos;    // Array of photos
    private int currentIndex = 0;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    public float swipeThreshold = 50f; // Minimum swipe distance to detect a swipe

    private void Start()
    {
        if (photos.Length > 0)
            photoDisplay.sprite = photos[currentIndex];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Optional: You can use this to show swipe progress if needed.
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endTouchPosition = eventData.position;
        HandleSwipe();
    }

    private void HandleSwipe()
    {
        float deltaX = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(deltaX) > swipeThreshold)
        {
            if (deltaX > 0)
            {
                SwipeRight();
            }
            else
            {
                SwipeLeft();
            }
        }
    }

    private void SwipeLeft()
    {
        if (currentIndex < photos.Length - 1)
        {
            currentIndex++;
            UpdatePhoto();
        }
    }

    private void SwipeRight()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdatePhoto();
        }
    }

    private void UpdatePhoto()
    {
        photoDisplay.sprite = photos[currentIndex];
    }
}
