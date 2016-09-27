using UnityEngine;
using System.Collections;

public class spawnComets : MonoBehaviour {
    public GameObject comet;
    public float bpm;

    void Start()
    {
        InvokeRepeating("SpawnComet", Time.time,  (Time.deltaTime * 5000) / bpm);
    }

	void SpawnComet () {
        Vector3 v = new Vector3(Random.Range(-8,8), Random.Range(-5, 5), Random.Range(-3, 15));
        Instantiate(comet, v, Quaternion.Euler(0, 180,0));
	}
}
