using UnityEngine;
using TMPro;
using UnityEngine.Timeline;

public class fps : MonoBehaviour {
    public TextMeshProUGUI fpstext;

    private float pollingTime = 1f;
    private float time;
    private int framecount;


    void Update() {
        time += Time.deltaTime;

        framecount++;

        if (time >= pollingTime)
        {
            int framerate = Mathf.RoundToInt(framecount / time);
            fpstext.text = framerate.ToString() + " Fps";


            time -= pollingTime;
            framecount = 0;
        }
    }
}
