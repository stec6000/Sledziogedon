using UnityEngine;
using System.Collections;

public class Kolizjabokow : MonoBehaviour {
    public int direction = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "platform" || col.gameObject.tag == "PlayerSide")
        {
            transform.parent.GetComponent<PlayerController>().setMoveable(direction);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform" || col.gameObject.tag == "PlayerSide")
        {
            transform.parent.GetComponent<PlayerController>().setMoveable(0);
        }
    }
}
