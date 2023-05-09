#if (UNITY_EDITOR)


using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;
    private float time;
    private int frameCount;

    private void Start()
    {
       FpsText.enabled = true;
    }

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if (time >= 1f)
        {
            FpsText.text = frameCount.ToString() + "FPS";

            time = 0;
            frameCount = 0;
        }
    }
}
#endif