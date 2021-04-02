using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ButtonAA : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;

    void FixedUpdate()
    {
        // Access Input Function
        player.GetComponent<PlayerMotor>().PlayerMove();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Player Accelerate
        player.GetComponent<PlayerMotor>().PlayerAcceleration();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Player Attack -- for Now Do Nothing
        player.GetComponent<PlayerMotor>().PlayerDeceleration();
    }
}
