using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speedMetersPerSec;
    public Slider slider;
    public TMP_Text text;

    private void Update()
    {
        speedMetersPerSec=rigidbody.velocity.magnitude;
        float milesPerHour = speedMetersPerSec * 2.23693629f;
        slider.value= milesPerHour;
        text.text = milesPerHour.ToString("N0") + " MPH";
    }

}
