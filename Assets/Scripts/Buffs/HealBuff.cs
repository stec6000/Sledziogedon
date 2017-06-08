using UnityEngine;
using System.Collections;

public class HealBuff : MonoBehaviour {
    public float timetoend = 0;
    GameObject player;

    void Start()
    {
        if (Utils.FindObjectInChildWithTag(gameObject, "hearth") == null)
        {
            GameObject shieldSprite = Instantiate(Resources.Load("hearth") as GameObject,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z),
            Quaternion.identity) as GameObject;
            shieldSprite.transform.parent = gameObject.transform;
        }
        if (timetoend == 0)
            timetoend = 8 + Time.time;
    }

    void Update()
    {
        if (Time.time >= timetoend)
        {
            endBuff();
        }
    }

    void endBuff()
    {
        if (GetComponents<HealBuff>().Length < 2)
        {
            Destroy(Utils.FindObjectInChildWithTag(gameObject, "hearth"));
        }
        Destroy(gameObject.GetComponent(typeof(HealBuff)) as HealBuff);
    }
}
