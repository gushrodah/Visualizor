using UnityEngine;
using System.Collections;

public class BurstSpawn : MonoBehaviour {
    
    Manager music;
	public TYPE musicType;
	public float max;
    public GameObject burstPart;
	float count = 0.0f;

	void Start () {
        music = GameObject.Find("spectrum equalizer").GetComponent<Manager>();
	}

    void Update()
    {
		if (music.OnBeat(musicType)&& count >.5f)
        {
            Vector3 v = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(1, 10));
            Instantiate(burstPart, v, Quaternion.Euler(Random.Range(-90,90), Random.Range(-90, 90), Random.Range(-90, 90)));
			count = 0;
        }
		count += Time.deltaTime;
    }
}
