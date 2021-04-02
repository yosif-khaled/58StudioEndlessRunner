using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ButtonLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Player Motion Function
        player.GetComponent<PlayerMotor>().isMovingLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.GetComponent<PlayerMotor>().isMovingLeft = false;
    }
}
