using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCubes : MonoBehaviour
{
    public int Band; // int variable called Band 

    public float StartScale; // float variables for what the scale will start at
    public float ScaleMult; // float variable for what the scale should multiply by 

    public bool BufferInUse; // bool for when the buffer is in use

    Material Materials; // cache variable for accessing the materials component in unity  


    // Start is called before the first frame update
    void Start()
    {
        Materials = GetComponent<MeshRenderer>().materials[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        if (BufferInUse)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioData.BufferBands[Band] * ScaleMult) + StartScale, transform.localScale.z);
            // transforms the blocks by the y where the x remains the same and the y retrieves the FrequencyBands array from the audiodata script and appends them at a band multiplied by the scalemult variable with the startscale added to it, and the z stays the same just like the x axis
            Color newcolor = new Color (AudioData.AudioBandBuffer[Band], AudioData.AudioBandBuffer[Band], AudioData.AudioBandBuffer[Band]); // when buffer bands are on, a temp variable called newcolor holds the rgb between the number 0-1 since under every arguement audiodatas bufferbands or audiobands band number controls the rgb of the block
            Materials.SetColor ("_EmissionColor", newcolor); // the cache variable changes the color of the emissioncolor to newcolor which is a value between 0-1
        }

        if (!BufferInUse)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioData.FrequencyBands[Band] * ScaleMult) + StartScale, transform.localScale.z);
            // transforms the blocks by the y where the x remains the same and the y retrieves the FrequencyBands array from the audiodata script and appends them at a band multiplied by the scalemult variable with the startscale added to it, and the z stays the same just like the x axis
            Color newcolor = new Color(AudioData.AudioBand[Band], AudioData.AudioBand[Band], AudioData.AudioBand[Band]); 
            Materials.SetColor("_EmissionColor", newcolor);
        }
    }
}
