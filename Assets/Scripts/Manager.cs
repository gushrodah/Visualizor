using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TYPE
{
	BASS,
	SNARE,
	MID
};

/* holds/spawns/manipulates all modifiable objects*/
public class Manager : MonoBehaviour {

	public AudioSource audioSource;
	public float []freqData;                // all samples
	int numSamples = 8192;
	float numFrames = 15;



	struct rangeData
	{
		public int start;
		public int end;
		public int increment;
		public float cutoff;

		public rangeData(int s, int e, int i, float c)
		{
			start = s;
			end = e;
			increment = i;
			cutoff = c;
		}
	};
		
	Dictionary<TYPE,rangeData> musicType = new Dictionary<TYPE,rangeData>();

    void Start () {
		audioSource = GetComponent<AudioSource>();
		freqData    = new float[numSamples];

		musicType.Add(TYPE.BASS, new rangeData(0,200,4,.02f));
		musicType.Add(TYPE.SNARE, new rangeData (2000, 4000, 20, .0014f));
		//musicType.Add(TYPE.SNARE, new rangeData (1000, 4000, 60));
		musicType.Add (TYPE.MID, new rangeData (400,800,8,0));

		InvokeRepeating("ExtractData", 0, 1.0f / numFrames);
    }
		
	void ExtractData()
	{
		audioSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
	}

	// returns highest if ranged
	public float GetData(int start, int range=1)
	{
		float l = freqData[start];
		for (int j = 1; j < range ; j++)
		{
			float r = freqData[start + j];
			l = (l > r) ? l : r;
		}
		return l;
	}

	public float GetData(TYPE t, int increment)
	{
		float l = freqData[musicType[t].start];
		//int range = musicType[t].end - musicType[t].start;
		for (int j = 1; j <= musicType[t].increment ; j++)
		{
			float r = freqData[(increment * musicType[t].increment)+musicType[t].start + j];
			l = (l > r) ? l : r;
		}
		//Debug.Log (l);
		return l;
	}

	public float GetRangeAverage(TYPE t)
	{
		float count = 0.0f;
		float range = musicType[t].end - musicType[t].start;
		int start = musicType [t].start;
		for(int i=start; i < range+start; i++)
		{
			count += freqData [i];
		}
		return (count / range);
	}

	public bool OnBeat(TYPE t)
	{
		return (GetRangeAverage (t) > musicType[t].cutoff);
	}

	void Update()
	{	
		//Debug.Log(GetRangeAverage (TYPE.SNARE));
	}
}
