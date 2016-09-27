using UnityEngine;
using System.Collections;

public class CapsuleGenerator : MonoBehaviour {

	public GameObject c_window;

	public int numWindows;
	public int vertDivisions;
	public float segmentOccurance;	//change to 1/segmentOccurance
	public float radius;

	// Use this for initialization
	void Start () {
		if (numWindows ==0) {
			numWindows = 30;
		}
		if (vertDivisions==0) {
			vertDivisions = 10;
		}
		if (radius==0) {
			radius = 5;
		}
		// if not declared, even division with rows
		if (segmentOccurance == 0) {
			segmentOccurance = 2;
		}
		GenerateWindows ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void GenerateWindows()
	{
		
		float a = 90 / (vertDivisions/2);
		float rad = radius;
		float angIncr = segmentOccurance;
		for(float i = 0; i < 90;i+=a){
			// calculate y
			float y = radius * Mathf.Sin(i*Mathf.Deg2Rad);
			// change radius size for each row
			rad = radius * Mathf.Cos (i * Mathf.Deg2Rad);
			float ang = 0;
			// create circle of windows

			for (; ang < 360; ang += angIncr){
				Vector3 pos = new Vector3 (rad * Mathf.Cos (ang* Mathf.Deg2Rad), y, rad * Mathf.Sin (ang* Mathf.Deg2Rad));
				// top half
				GameObject win = Instantiate (c_window, pos, Quaternion.identity) as GameObject;
				win.transform.LookAt (GameObject.FindGameObjectWithTag("MainCamera").transform);
				win.transform.SetParent (this.gameObject.transform);
				// bottom half
				if (i != 0) {
					Vector3 pos2 = new Vector3 (rad * Mathf.Cos (ang* Mathf.Deg2Rad), -y, rad * Mathf.Sin (ang* Mathf.Deg2Rad));
					GameObject winNeg = Instantiate (c_window, pos2, Quaternion.identity) as GameObject;
					winNeg.transform.LookAt (GameObject.FindGameObjectWithTag("MainCamera").transform);
					winNeg.transform.SetParent (this.gameObject.transform);
				}
			}
			// change increment angle
			// angle increment
			angIncr += (radius -rad)* segmentOccurance;
			if (angIncr > 360)
				angIncr = 360;
			angIncr = (int)angIncr;
			// get even incr
			while (360 % angIncr != 0) {
				angIncr++;
			}
		}
	}
}
