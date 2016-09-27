using UnityEngine;
using System.Collections;

public class spawnTimer : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		float temp = transform.position.z;
		if (temp > 5) {
			transform.position -= new Vector3 (0, 0, 5);
		}
	}
}
