using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    //public float fps;
    public TMP_Text textComponent;
    public float lastTime;
    float smoothFps = 0;
    int fpsNumber;
    private void Update()
    {
        if (lastTime + 1 <= Time.time)
        {
            lastTime = Time.time;
            textComponent.text = "fps: " + fpsNumber.ToString("N0");

            fpsNumber = 0;
        }
        else
        {
            //fps = 1 / Time.deltaTime;
            fpsNumber++;
        }
    }
}
