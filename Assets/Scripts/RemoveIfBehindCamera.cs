using UnityEngine;
using System.Collections;

public class RemoveIfBehindCamera : MonoBehaviour {
    private Transform cameraTransform;

    // Use this for initialization
    void Start () {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.transform.position.x + 20 < cameraTransform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
