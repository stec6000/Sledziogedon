using UnityEngine;
using System.Collections;

public class fishSwimmer : MonoBehaviour {

    private int state = 0;
    private Transform targetTransform;
	// Use this for initialization
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }

	void Start () {
        state = -1;
        targetTransform = transform.parent;
    }
	
	// Update is called once per frame
	void Update () {
        if (state == -1)
            Go();
	}

    void Go()
    {
        transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(targetTransform.position.x, targetTransform.position.y - 0.22f, transform.position.z),
                25 * Time.deltaTime);
        if (transform.position == new Vector3(targetTransform.position.x, targetTransform.position.y - 0.22f, transform.position.z))
            state = 0;
    }

    public void goToPos(Transform transform)
    {
        targetTransform = transform;
        state = -1;
    }

    public void animationDestroy()
    {
        gameObject.GetComponent<Animator>().SetBool("dead", true);
        gameObject.AddComponent<AnimationAutoDestroy>();
        Destroy(gameObject.GetComponent<fishSwimmer>());
    }
}
