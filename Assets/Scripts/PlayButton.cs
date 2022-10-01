using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject pauseButton;
    public void OnPointerDown(PointerEventData data)
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
        pauseButton.SetActive(true);
    }
}
