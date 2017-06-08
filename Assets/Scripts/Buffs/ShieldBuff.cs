using UnityEngine;
using System.Collections;

public class ShieldBuff : MonoBehaviour {
    public float timetoend = 0;
    GameObject player;

    void Start () {
        if(Utils.FindObjectInChildWithTag(gameObject, "shield") == null)
        {
            GameObject shieldSprite = Instantiate(Resources.Load("Shield") as GameObject,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z),
            Quaternion.identity) as GameObject;
            shieldSprite.transform.parent = gameObject.transform;
        }
        if(timetoend == 0)
            timetoend = 9 + Time.time;
    }
	
	void Update () {
        if (Time.time >= timetoend)
        {
            endBuff();
        }
    }

    void endBuff()
    {
        if (GetComponents<ShieldBuff>().Length < 2)
        {
            Destroy(Utils.FindObjectInChildWithTag(gameObject, "shield"));
        }
        Destroy(gameObject.GetComponent(typeof(ShieldBuff)) as ShieldBuff);
    }
}
