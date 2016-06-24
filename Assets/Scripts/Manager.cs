using UnityEngine;
using System.Collections;

/* holds/spawns/manipulates all modifiable objects*/
public class Manager : MonoBehaviour {

    // frequency data
    specAnalyzer SpecData;

    public GameObject bassCube, snareCube, midObj;

    // Cube Objects
    public GameObject[] bassCubes;
    public GameObject[] snareCubes;
    public GameObject[] midCubes;
    GameObject bass, snare, mid;

    void Start () {
        
        GameObject temp = GameObject.Find("music");
        SpecData = temp.GetComponent<specAnalyzer>();

        CreateCubes(10);    // create cube data
    }
	
	void Update () {
        
        //snareL.range = SpecData.freqData[240] * 800;
        //melody.range = SpecData.freqData[150] * 300;

        //SpecData.ReduceData(64);
        UpdateCubes();
        //Testing();
    }

    void CreateCubes(int radius)
    {
        bass = new GameObject();
        snare = new GameObject();
        mid = new GameObject();
        int size = 50;
        //SpecData.ReduceData(64);
        bassCubes = new GameObject[size];
        snareCubes = new GameObject[size];
        midCubes = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            float angle = i * Mathf.PI * 2 / size;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, -3, Mathf.Sin(angle) * radius + 2);
            bassCubes[i] = Instantiate(bassCube) as GameObject;
            bassCubes[i].transform.position = pos;
            //bassCubes[i].transform.Rotate(new Vector3(angle,0,angle));
            bassCubes[i].transform.SetParent(bass.transform);
        }
        for (int i = 0; i < size; i++)
        {
            float angle = i * Mathf.PI * 2 / size;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius + 2);
            snareCubes[i] = Instantiate(snareCube) as GameObject;
            snareCubes[i].transform.position = pos;
            //snareCubes[i].transform.Rotate(new Vector3(angle, 0, angle));
            snareCubes[i].transform.SetParent(snare.transform);
        }
        for (int i = 0; i < size; i++)
        {
            float angle = i * Mathf.PI * 2 / size;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius + 2);
            midCubes[i] = Instantiate(midObj) as GameObject;
            midCubes[i].transform.position = pos;
            //midCubes[i].transform.Rotate(new Vector3(angle, 0, angle));
            midCubes[i].transform.SetParent(mid.transform);
        }
    }

    void UpdateCubes()
    {
        /*for (int i = 0; i < bassCubes.Length; i++)
        {
            bassCubes[i].transform.localScale = new Vector3(.5f, SpecData.bassSamples[i] * 64, .5f);
        }
        bass.transform.Rotate(new Vector3(-10, 10, 0) * Time.deltaTime);
        for (int i = 0; i < snareCubes.Length; i++)
        {
            snareCubes[i].transform.localScale = new Vector3(.5f, SpecData.snareSamples[i] * 400, .5f);
        }
        snare.transform.Rotate(new Vector3(0, -10, 10) * Time.deltaTime);
        for (int i = 0; i < midCubes.Length; i++)
        {
            midCubes[i].transform.localScale = new Vector3(.5f, SpecData.midSamples[i] * 100, .5f);
        }
        mid.transform.Rotate(new Vector3(10, 0, -10) * Time.deltaTime);*/
        
        float yVal;
        for (int i = 0; i < 200; i += 4)
        {
            float l = SpecData.freqData[i];
            for (int j = 1; j < 4; j++)
            {
                float r = SpecData.freqData[i + j];
                l = (l > r) ? l : r;
            }
            bassCubes[i/4].transform.localScale = new Vector3(.5f, l * 64, .5f);
        }
        bass.transform.Rotate(new Vector3(-10, 10, 0) * Time.deltaTime);

        for (int i = 1000; i < 4000; i += 60)
        {
            float l = SpecData.freqData[i];
            for (int j = 1; j < 60; j++)
            {
                float r = SpecData.freqData[i + j];
                l = (l > r) ? l : r;
            }
            snareCubes[(i-1000)/60].transform.localScale = new Vector3(.5f, l * 400, .5f);
        }
        snare.transform.Rotate(new Vector3(0, -10, 10) * Time.deltaTime);
        
        for (int i = 400; i < 800; i += 8)
        {
            float l = SpecData.freqData[i];
            for (int j = 1; j < 8; j++)
            {
                float r = SpecData.freqData[i + j];
                yVal = (l > r) ? l : r;
            }
            midCubes[(i-400)/8].transform.localScale = new Vector3(.5f, l * 100, .5f);
        }
        mid.transform.Rotate(new Vector3(10, 0, -10) * Time.deltaTime);
    }



    void Testing()
    {
        // test all samples
        //for (int i = 0; i < SpecData.freqData.Length - 1; i++)
        //{
        //    Debug.DrawLine(new Vector3(i - 1, SpecData.freqData[i] + 10, 0), new Vector3(i, SpecData.freqData[i + 1] + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(SpecData.freqData[i]) + 10, 2), new Vector3(i, Mathf.Log(SpecData.freqData[i]) + 10, 2), Color.cyan);
        //}
        // test reduced samples
        //SpecData.ReduceData(64);
        //for (int i = 0; i < SpecData.reducedData.Length - 1; i++)
        //{
        //    Debug.DrawLine(new Vector3(i - 1, SpecData.reducedData[i] + 10, 0), new Vector3(i, SpecData.reducedData[i + 1] + 10, 0), Color.magenta);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(SpecData.reducedData[i]) + 10, 2), new Vector3(i, Mathf.Log(SpecData.reducedData[i]) + 10, 2), Color.green);
        //}
    }
}
