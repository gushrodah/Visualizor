using UnityEngine;
using System.Collections;

public class LB : MonoBehaviour {

    // Light Objects
    public GameObject L1;
    Light bassL;

    // frequency data
    specAnalyzer SpecData;

    void Start () {
        bassL = L1.GetComponent<Light>();

        GameObject temp = GameObject.Find("music");
        SpecData = temp.GetComponent<specAnalyzer>();
    }
	
	void Update () {
        ChangeRange(SpecData.freqData[50]);
    }

    void ChangeRange(float value)
    {
        bassL.range = value * 100;
    }
}
