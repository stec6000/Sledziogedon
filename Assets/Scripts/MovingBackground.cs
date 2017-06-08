using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {
    public float moveByNumberWidths = 1;
    public float moveCorrection = 0.3f;
    public bool moveAlways = false;

    private Transform cameraTransform;
    private Vector2 cameraHalfWidthHeight;

    private float objectwidth;
    //Polowa 
    // Use this for initialization
    void Start () {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2(cameraTransform.position.x, cameraTransform.position.y);

        objectwidth = gameObject.GetComponent<Renderer>().bounds.size.x;
    }
	
	// Update is called once per frame
	void Update () {
        if(moveAlways)
            transform.Translate(-Time.deltaTime, 0, 0);
        if (isBehindCamera())
            moveObject();
    }

    bool isBehindCamera ()
    {
        if (transform.position.x + (objectwidth / 2) < cameraTransform.position.x - cameraHalfWidthHeight.x)
            return true;
        return false;
    }

    void moveObject ()
    {
        transform.position += new Vector3(objectwidth * moveByNumberWidths - moveCorrection, 0, 0);
    }
}
