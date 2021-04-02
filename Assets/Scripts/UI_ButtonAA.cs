using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ButtonAA : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Player Accelerate
        player.GetComponent<PlayerMotor>().isAccelerating = true;
        Debug.Log("Is Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.GetComponent<PlayerMotor>().isAccelerating = false;
        Debug.Log("Is Released");
    }

}
