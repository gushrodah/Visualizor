using UnityEngine;
using System.Collections;

public class spectrumAnalyzer : MonoBehaviour {
    public int numOfSamples = 64; //Min: 64, Max: 8192
    public GameObject bass, snare, c3, c4;

    public AudioSource aSource;

    public float[] freqData;        // all data
    public float[] band;            // different freq

    public GameObject[] g;

    void Start()
    {
        freqData = new float[numOfSamples];

        int n = freqData.Length;

        // checks n is a power of 2 in 2's complement format
        //if ((n-(n - 1)) != 0)
        //{
        //    Debug.LogError("freqData length " + n + " is not a power of 2!!! Min: 64, Max: 8192.");
        //    return;
        //}

        int k = 0;
        for (int j = 0; j < freqData.Length; j++)
        {
            n = n / 2;
            if (n <= 0) break;
            k++;
        }

        band = new float[k + 1];
        g = new GameObject[k + 1];

        // drawing spheres
        //for (int i = 0; i < band.Length; i++)
        //{
        //    band[i] = 0;
        //    g[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    //g[i].renderer.material.SetColor("_Color", Color.cyan);
        //    g[i].transform.position = new Vector3(i, 0, 0);

        //}

        InvokeRepeating("check", 0.0f, 1.0f / 30.0f); // update at 30 fps


    }

    private void check()
    {
        aSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);

        int k = 0;
        int crossover = 2;

        for (int i = 0; i < freqData.Length; i++)
        {
            float d = freqData[i];
            float b = band[k];

            // find the max as the peak value in that frequency band.
            band[k] = (d > b) ? d : b;

            if (i > (crossover - 3))
            {
                k++;
                crossover *= 2;   // frequency crossover point for each band.
                //Vector3 tmp = new Vector3(g[k].transform.position.x, band[k] * 32, g[k].transform.position.z);
                //g[k].transform.position = tmp;
                //g[k].transform.localScale = new Vector3(1, band[k] * 32, 1);
                bass.transform.position = new Vector3(bass.transform.position.x, band[4] * 32, bass.transform.position.z);
                //bass.transform.localScale = new Vector3(band[4] * 32, 1 ,1);
                snare.transform.localScale = new Vector3(1, band[12] * 1024, 1);

                band[k] = 0;
            }
        }
    }
}
