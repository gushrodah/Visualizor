using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		Invoke ("DestroyThis", lifetime);
	}
	
	void DestroyThis()
	{
		Destroy (gameObject);
	}
}
