using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string acceptedTag; // The tag this zone accepts
    public static int score = 0; // Static score for correct/incorrect drops

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag; // Get the dragged object

        if (draggedObject != null && draggedObject.CompareTag(acceptedTag))
        {
            // Correct drop
            Debug.Log("Correct Drop!");
            score += 10; // Increase score for correct drop
            draggedObject.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition; // Snap the object to the drop zone
        }
        else
        {
            // Incorrect drop, return object and deduct score
            Debug.Log("Incorrect Drop!");
            score -= 5; // Decrease score for incorrect drop
            draggedObject.GetComponent<DragAndDrop>().ReturnToStartPosition(); // Return object to start position
        }

        // Update score (optional, if you want to log it after every drop)
        Debug.Log("Score: " + score);
    }
}
