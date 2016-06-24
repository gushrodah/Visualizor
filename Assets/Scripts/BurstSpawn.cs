using UnityEngine;
using System.Collections;

public class BurstSpawn : MonoBehaviour {
    
    specAnalyzer music;
    public GameObject burstPart;
    float count;
	void Start () {
        music = GameObject.Find("music").GetComponent<specAnalyzer>();
        
	}

    void Update()
    {
        //Debug.Log(music.bassSamples[7]);
        if (music.freqData[7] > .1f && count > .75f)
        {
            Vector3 v = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), Random.Range(-3, 10));
            Instantiate(burstPart, v, Quaternion.Euler(Random.Range(-90,90), Random.Range(-90, 90), Random.Range(-90, 90)));
            count = 0;
        }
        count+= Time.deltaTime;
    }
	
	void CheckData () {
        
	}
}
