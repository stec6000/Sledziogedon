using UnityEngine;
using System.Collections;

public class singleFish : MonoBehaviour {
    public Vector2 gravityRange = new Vector2(0.4f, 0.7f);

    private Transform cameraTransform;
    private Vector2 cameraHalfWidthHeight;

    public bool fishTopDown = false;
    private Rigidbody2D rig;
    private float rotation = 180;

    void Start () {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(gravityRange.x, gravityRange.y);

        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2(cameraTransform.position.x, cameraTransform.position.y);

        if (fishTopDown)
        {
            rig = GetComponent<Rigidbody2D>();
            rig.AddForce(new Vector2(0, 350));
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        if (isFishOutOfScreen())
            killFish();
        if (fishTopDown)
        {
            if (rig.velocity.y <0)
                if (rotation != 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(rotation-5, 0, 0);
                    rotation = rotation - 5;
                    if(rotation == 170)
                    {
                        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                    }
                }
        }
    }

    bool isFishOutOfScreen()
    {
        if (transform.position.y < (cameraTransform.position.y - (cameraHalfWidthHeight.y + 2f)))
            return true;
        if (transform.position.x < (cameraTransform.position.x - (cameraHalfWidthHeight.x + 2f)))
            return true;
        return false;
    }

    public void animationDestroy()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        gameObject.GetComponent<Animator>().SetBool("dead", true);
        gameObject.AddComponent<AnimationAutoDestroy>();
        gameObject.transform.tag = "Untagged";
        Destroy(gameObject.GetComponent<singleFish>());
    }

    void killFish()
    {
        Destroy(gameObject);
    }
}
