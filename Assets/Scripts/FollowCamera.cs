using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
    private Transform cameraTransform;

    // Use this for initialization
    void Start () {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector2(cameraTransform.position.x, transform.position.y);
	}
}
