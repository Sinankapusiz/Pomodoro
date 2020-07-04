using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBack : MonoBehaviour
{
    public GameObject pausePanel;
    public void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            pausePanel.SetActive(true);
            // Game is paused, start service to get notifications
        }
        else
        {
            // Game is unpaused, stop service notifications. 
        }
    }
}
