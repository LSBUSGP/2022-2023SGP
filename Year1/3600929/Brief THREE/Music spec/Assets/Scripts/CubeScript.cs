using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int Band; // int variable called Band 
    
    public float StartScale; // float variables for what the scale will start at
    public float ScaleMult; // float variable for what the scale should multiply by 

    public bool BufferInUse;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BufferInUse) 
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioData.BufferBands[Band] * ScaleMult) + StartScale, transform.localScale.x);
            // transforms the blocks by the y where the x remains the same and the y retrieves the FrequencyBands array from the audiodata script and appends them at a band multiplied by the scalemult variable with the startscale added to it, and the z stays the same just like the x axis
        }

        if (!BufferInUse) 
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioData.FrequencyBands[Band] * ScaleMult) + StartScale, transform.localScale.x);
            // transforms the blocks by the y where the x remains the same and the y retrieves the FrequencyBands array from the audiodata script and appends them at a band multiplied by the scalemult variable with the startscale added to it, and the z stays the same just like the x axis
        }
    }
}
