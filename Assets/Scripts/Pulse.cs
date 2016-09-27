using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	Manager data;

	public TYPE musicType;
	public float maxRange;
	public float scale;
	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Manager> ();
		if (scale == 0) {
			scale = 3.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (data.OnBeat (musicType))
			gameObject.transform.localScale = new Vector3 (scale, scale, scale);
		else {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
}
