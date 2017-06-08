using UnityEngine;
using System.Collections;

public class BuffObject : MonoBehaviour {
    public string name = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.rotation.z) > 0.1)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(name == "Multiply")
            {
                MultiplyBuff buff = col.gameObject.AddComponent<MultiplyBuff>();
                buff.setState(1);
            }
            

            if(name == "Shield")
            {
                foreach (GameObject playerObject in GameObject.FindGameObjectsWithTag("Player"))
                {
                    ShieldBuff shield = playerObject.gameObject.AddComponent<ShieldBuff>();
                }
            }

            if (name == "Swim")
            {
                foreach (GameObject playerObject in GameObject.FindGameObjectsWithTag("Player"))
                {
                    SwimBuff swim = playerObject.gameObject.AddComponent<SwimBuff>();
                }
            }

            if (name == "Heal")
            {
                foreach (GameObject playerObject in GameObject.FindGameObjectsWithTag("Player"))
                {
                    HealBuff swim = playerObject.gameObject.AddComponent<HealBuff>();
                }
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
