using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject pausePanel;
    
    public void OnPointerDown(PointerEventData data)
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
