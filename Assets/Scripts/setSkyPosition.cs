using UnityEngine;
using System.Collections;

public class setSkyPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, PlayerPrefs.GetFloat("High"), transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
