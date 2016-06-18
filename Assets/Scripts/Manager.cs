using UnityEngine;
using System.Collections;

/* holds/spawns/manipulates all modifiable objects*/
public class Manager : MonoBehaviour {

    // frequency data
    public specAnalyzer SpecData;

    // Light Objects
    public GameObject L1, L2, L3;
    Light bassL, snareL, melody;

    // Cube Objects
    GameObject[] cubes;

    void Start () {
        bassL = L1.GetComponent<Light>();
        snareL = L2.GetComponent<Light>();
        melody = L3.GetComponent<Light>();

        CreateCubes(10);
    }
	
	void Update () {
        ChangeRange(SpecData.freqData[50]);
        snareL.range = SpecData.freqData[240] * 800;
        melody.range = SpecData.freqData[150] * 300;

        SpecData.ReduceData(64);
        UpdateCubes();
        //Testing();
    }

    void CreateCubes(int radius)
    {
        //SpecData.ReduceData(64);
        cubes = new GameObject[SpecData.reducedData.Length];
        for (int i = 0; i < SpecData.reducedData.Length; i++)
        {
            float angle = i * Mathf.PI * 2 / SpecData.reducedData.Length;
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, -3, Mathf.Sin(angle) * radius + 2);
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }

    void UpdateCubes()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localScale = new Vector3(1, SpecData.reducedData[i]);
        }
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
        SpecData.ReduceData(64);
        for (int i = 0; i < SpecData.reducedData.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, SpecData.reducedData[i] + 10, 0), new Vector3(i, SpecData.reducedData[i + 1] + 10, 0), Color.magenta);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(SpecData.reducedData[i]) + 10, 2), new Vector3(i, Mathf.Log(SpecData.reducedData[i]) + 10, 2), Color.green);
        }
    }
}
