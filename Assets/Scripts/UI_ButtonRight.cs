using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Player Motion Function
        player.GetComponent<PlayerMotor>().isMovingRight = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Return -- Do Nothing
        player.GetComponent<PlayerMotor>().isMovingRight = false;
    }
}
