using UnityEngine;
using System.Collections;

public class circleEqualizer : MonoBehaviour {

	Manager data;

	public TYPE musicType;
	public int scale;
	public int size;
	GameObject[] objList;
	public GameObject objToSpawn;
	public int radius;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Manager> ();
		objList = new GameObject[size];
		for (int i = 0; i < size; i++)
		{
			float angle = i * Mathf.PI * 2 / size;
			Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius + 2);
			objList[i] = Instantiate(objToSpawn) as GameObject;
			objList[i].transform.position = pos;
			//objList[i].transform.Rotate(new Vector3(angle,0,angle));
			objList[i].transform.SetParent(gameObject.transform);
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < size; i++) {
			float f = data.GetData(musicType,i);
			objList[i].transform.localScale = new Vector3(.5f, f * scale, .5f);
		}
	}
}
