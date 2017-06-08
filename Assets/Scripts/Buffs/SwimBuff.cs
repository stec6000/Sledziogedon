using UnityEngine;
using System.Collections;

public class SwimBuff : MonoBehaviour {
    public float timetoend = 0;

    void Start()
    {
        if (Utils.FindObjectInChildWithTag(gameObject, "fishSwimmer") == null)
        {
            GameObject shieldSprite = Instantiate(Resources.Load("fishSwimmer") as GameObject,
            new Vector3(Camera.main.transform.position.x, gameObject.transform.position.y - 0.22f, gameObject.transform.position.z),
            Quaternion.identity) as GameObject;
            shieldSprite.transform.parent = gameObject.transform;
            if (gameObject.GetComponent<PlayerController>().facingRight)
                shieldSprite.gameObject.transform.rotation = Quaternion.Euler(180, 0, 90);
            else
                shieldSprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (timetoend == 0)
            timetoend = 5 + Time.time;
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
        if (GetComponents<SwimBuff>().Length < 2)
        {
            GameObject swim = Utils.FindObjectInChildWithTag(gameObject, "fishSwimmer");
            if (swim != null)
                swim.GetComponent<fishSwimmer>().animationDestroy();
        }
        Destroy(gameObject.GetComponent(typeof(SwimBuff)) as SwimBuff);
    }
}
