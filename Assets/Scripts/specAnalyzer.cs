﻿using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class specAnalyzer : MonoBehaviour {
    // Audio stuff
    AudioSource audioSource;
    public float []freqData;                // all samples
    public int numSamples;
    public float[] reducedData;

    public float numFrames;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        freqData    = new float[numSamples];
               
        // get data 15 fps
        InvokeRepeating("ExtractData", 0, 1.0f / numFrames);
	}
	
    void ExtractData()
    {
        audioSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
    }

    // newSampleSize has to be mult of 2
    public void ReduceData(int newSampleSize)
    {
        // error checking
        if (newSampleSize > numSamples) return;
        //Assert.IsTrue(newSampleSize > numSamples);

        int indexMod = numSamples / newSampleSize;

        reducedData = new float[newSampleSize];
        int index = 0;
        for(int i = 0; i < numSamples;)
        {
            // get average of 
            /*float temp = 0;
            for (int j = 0; j < indexMod; j++)
            {
                temp += freqData[i + j];
                temp /= indexMod;
            }*/
            
            reducedData[index] = freqData[i];

            index++;
            i += indexMod;
        }
    }
}