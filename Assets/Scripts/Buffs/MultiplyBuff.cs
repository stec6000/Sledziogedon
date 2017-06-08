using UnityEngine;
using System.Collections;

public class MultiplyBuff : MonoBehaviour {
    int state = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(state == 1)
        {
            setState(0);
            for (float i = 4; i > 0; i = i-0.5f)
            {
                GameObject player = Instantiate(gameObject, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), 
                    Quaternion.identity) as GameObject;
            }
        }
        if(state == 0)
        {
            setState(2);
        }
        if(state == 2)
        {
            Destroy(gameObject.GetComponent(typeof(MultiplyBuff)) as MultiplyBuff);
            int a = 1;
        }
	}

    public void setState(int a)
    {
        state = a;
    }
}
