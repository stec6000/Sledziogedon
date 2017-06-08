using UnityEngine;
using System.Collections;

public class PutOnLeftSide : MonoBehaviour {
    string Buffname = "";
	// Use this for initialization
	void Start () {
        Transform cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Vector2 cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2(cameraTransform.position.x, cameraTransform.position.y);

        transform.position = new Vector3(-(cameraHalfWidthHeight.x + 0.25f), transform.position.y, transform.position.z);
    }
}
