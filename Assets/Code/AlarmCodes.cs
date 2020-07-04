using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmCodes : MonoBehaviour
{
    AudioSource alarm;
    bool playAndPause ;
    void Start()
    {
        alarm = GetComponent<AudioSource>();
        //alarm.Play();
        //playAndPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playAndPause == true)
            {
                alarm.Pause();
                playAndPause = false;
            }
            else
            {
                alarm.Play();
                playAndPause = true;
            }               
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            alarm.Stop();
            playAndPause = false;
        }
    }
}
