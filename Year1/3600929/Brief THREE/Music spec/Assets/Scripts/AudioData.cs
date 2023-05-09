using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (AudioSource))] // grabs the audiosource component from unity right above the class
public class AudioData : MonoBehaviour
{

    AudioSource aS; // cache variable for audiosource is created

    public static float[] AudioBand = new float[4]; // float that will store the highest value
    public static float[] AudioBandBuffer = new float[4]; // float that will store the highest value in the buffer series
    public static float[] Samples = new float[512]; // float list that will hold the spectrumdata - static so that other scripts can access this variable
    public static float[] FrequencyBands = new float[4]; // new float array variable which will hold dthe frequencybands of the spectrumdata of only 4
    public static float[] BufferBands = new float[4]; // when the frequencyband is higher than the buffer, the frequency band becomes the band buffer 
    
    float[] DecreaseBuffer = new float[4]; // this float will decrease the band for a smoother transistion for the music cubes
    float[] FrequencyHighBand = new float[4]; // float for containing the highest frequency band

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>(); // aS holds the audiosource component 
    }

    // Update is called once per frame
    void Update()
    {
        AudioSpectrumData(); // method is called every frame
        CreateFrequencyBands();
        BandBuffer();
        MakeAudioBands();
    }

    void AudioSpectrumData() 
    {
        aS.GetSpectrumData(Samples, 0, FFTWindow.Blackman); // fftwindow helps prevent the leakage of spec data
    }

    void CreateFrequencyBands() // method for creating the freqbands 
    {
        int Count = 0; // temp variable callefd count
        for (int i = 0; i < 4; i++) // for loop till i is greater than 4
        {
            float Average = 0f; // temp variable called average is set to 0 for every new frequency band 
            int SampleCount = (int)Mathf.Pow(2, i) * 2; // temp int variable where the int is going in the power of 2 multiplied by 2 to hit the correct hertz for each band
            
            if (i == 3) // if i reaches 3
            {
                SampleCount += 2; // samplecount appends by 2
            }
        
            for (int j = 0; j < SampleCount; j++) // a for loop within a for loop where j is less than samplecount then increment
            {
                Average += Samples[Count] * (Count + 1); // adds the average variable to the samples Count and multiplies by the count variable added 1
                    Count++; // count variable increments
            }
            
            Average /= Count; // average variable divides by the count the programs in
            FrequencyBands[i] = Average * 10; // frequency band of i is the avaerage variable multiplied by 10
        }    
    }

    void BandBuffer() // method to smoothen the transition of the bands 
    {
        for (int x = 0; x < 4; x++) // for when x is less than 4 increment...
        {
            if (FrequencyBands[x] > BufferBands[x]) // if the frequency band is higher than the bufferbands
            {
                BufferBands[x] = FrequencyBands[x]; // buffer band becomes the frequency band
                DecreaseBuffer[x] = 0.01f; // the decrease buffer value 
            }
            
            if (FrequencyBands[x] < BufferBands[x]) // if the frequency is lower than the bufferbands
            {
                BufferBands[x] -= DecreaseBuffer[x]; // bufferbands is subtracted from the decrease buffer variable
                DecreaseBuffer[x] *= 1f;
            }
        }
    }

    void MakeAudioBands() // method for creating audiobands 
    {
        for (int y = 0; y < 4; y++) // for y is less than 4 increment by 1
        {
            if (FrequencyBands[y] > FrequencyHighBand[y]) // if frequency band (in the current y index) is greater than the highestfrequencyband
            {
                FrequencyHighBand[y] = FrequencyBands[y]; // that would mean the frequency band is the highest frequency band
            }
            AudioBand[y] = FrequencyBands[y] / FrequencyHighBand[y]; // audioband holds sthe value of frequencyband / by the highestfrequencyband at each y index in the for loop
            AudioBandBuffer[y] = BufferBands[y] / FrequencyHighBand[y]; // audiobuffer does the same calculation but wiwth the buffer settings on
        }
    }
}
