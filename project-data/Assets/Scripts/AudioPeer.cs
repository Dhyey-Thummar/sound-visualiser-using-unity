using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource audioSrc;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];
    public  float bufferDecreaseSens = 1.2f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {
        GetSpectrumData();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumData()
    {
        audioSrc.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if(freqBand[g]> bandBuffer[g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }
            else if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= bufferDecreaseSens;

            }
        }
    }
    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0f;
            int sampleCount = (int)Mathf.Pow(2, i + 1);

            if(i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;

            freqBand[i] = average * 10f;
        }
    }
}
