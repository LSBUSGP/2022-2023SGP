using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN MPH **

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public Text speedLabel; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private void Update()
    {
        // 3.6f to convert in miles
       
        speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " mph";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}
