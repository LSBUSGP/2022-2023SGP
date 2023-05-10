using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    private int FPS = 0;
    private float TimeElapsed = 0.0f;
    public Text FPSText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FPS += 1;
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= 1.0f)
        {
            TimeElapsed = 0.0f;
            FPSText.text = FPS.ToString() + " FPS";
            FPS = 0;
        }
    }
}
