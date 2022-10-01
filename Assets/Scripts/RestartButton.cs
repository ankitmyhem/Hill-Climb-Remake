using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
}
