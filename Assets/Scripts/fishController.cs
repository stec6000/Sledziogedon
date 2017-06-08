using UnityEngine;
using System.Collections;

public class fishController : MonoBehaviour {
    private Transform cameraTransform;
    private Vector2 cameraHalfWidthHeight;//Polowa 

    private GameObject fishPrefab;
    private float fishHitTimeStamp;
    public float fishHitCd = 0.2f;

    // Use this for initialization
    void Start () {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2 (cameraTransform.position.x, cameraTransform.position.y);

        fishPrefab = Resources.Load("fish") as GameObject;
        fishHitTimeStamp = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if(fishHitTimeStamp + fishHitCd <= Time.time)
            this.createFish();
    }

    void createFish()
    {
        GameObject fish = Instantiate(fishPrefab, new Vector3(
            Random.Range(cameraTransform.position.x - (cameraHalfWidthHeight.x - 1f), cameraTransform.position.x + (cameraHalfWidthHeight.x - 1f)), 
            cameraTransform.position.y + (cameraHalfWidthHeight.y+2f), 0), 
            Quaternion.identity) as GameObject;
        fishHitTimeStamp = Time.time + fishHitCd;
    }
}
