using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotX, rotY, rotZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotX,rotY,rotZ);
	}
}
