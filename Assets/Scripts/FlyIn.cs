using UnityEngine;
using System.Collections;

public class FlyIn : MonoBehaviour {
	public Vector3 startPos, endPos;
	public float speed;
	private Vector3 normal;
	// Use this for initialization
	void Start () {
		if (speed == 0) {
			speed = 5;
		}
		gameObject.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
		normal = (endPos - startPos).normalized;
		//transform.Translate(0,0,50);
		Debug.Log (normal);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = startPos;
		if (transform.position.z > endPos.z) {
			//transform.transform.Translate (normal *speed);
			//transform.position += normal * speed;
		}
	}
}
