using UnityEngine;
using System.Collections;

/* holds/spawns/manipulates all modifiable objects*/
public class Manager : MonoBehaviour {

    // frequency data
    public specAnalyzer SpecData;

    // Light Objects
    public GameObject L1, L2, L3;
    Light bassL, snareL, melody;
    public GameObject bassCube, snareCube;

    // Cube Objects
    public GameObject[] bassCubes;
    public GameObject[] snareCubes;
    GameObject bass, snare;

    void Start () {
        bassL = L1.GetComponent<Light>();
        snareL = L2.GetComponent<Light>();
        melody = L3.GetComponent<Light>();

        CreateCubes(10);    // create cube data
    }
	
	void Update () {
        ChangeRange(SpecData.freqData[50]);
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
        int size = SpecData.bassSamples.Length;
        //SpecData.ReduceData(64);
        bassCubes = new GameObject[size];
        snareCubes = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            float angle = i * Mathf.PI * 2 / size;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, -3, Mathf.Sin(angle) * radius + 2);
            bassCubes[i] = Instantiate(bassCube) as GameObject;
            bassCubes[i].transform.position = pos;
            bassCubes[i].transform.SetParent(bass.transform);
        }
        for (int i = 0; i < size; i++)
        {
            float angle = i * Mathf.PI * 2 / size;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius + 2);
            snareCubes[i] = Instantiate(snareCube) as GameObject;
            snareCubes[i].transform.position = pos;
            snareCubes[i].transform.SetParent(snare.transform);
        }
    }

    void UpdateCubes()
    {
        for (int i = 0; i < bassCubes.Length; i++)
        {
            bassCubes[i].transform.localScale = new Vector3(1, SpecData.bassSamples[i] * 128, 1);
            //bassCubes[i].transform.Translate(new Vector3(0, SpecData.bassSamples[i] * 2), 0);
        }
        bass.transform.Rotate(new Vector3(10, 10, 0) * Time.deltaTime);
        for (int i = 0; i < snareCubes.Length; i++)
        {
            snareCubes[i].transform.localScale = new Vector3(1, SpecData.snareSamples[i] * 400, 1);
        }
        snare.transform.Rotate(new Vector3(0, 10, 10) * Time.deltaTime);
    }

    void ChangeScale()
    {

    }

    void ChangeRange(float value)
    {
        bassL.range = value * 100;
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
        for (int i = 0; i < SpecData.reducedData.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, SpecData.reducedData[i] + 10, 0), new Vector3(i, SpecData.reducedData[i + 1] + 10, 0), Color.magenta);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(SpecData.reducedData[i]) + 10, 2), new Vector3(i, Mathf.Log(SpecData.reducedData[i]) + 10, 2), Color.green);
        }
    }
}
