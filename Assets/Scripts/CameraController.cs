using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    private float theFarestX = 0;

	void Start () {
        theFarestX = transform.position.x;
    }
	
	void Update () {
        float x = -99999;
        foreach (GameObject playerObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            float tempx = playerObject.transform.position.x;
            if (tempx > x)
            {
                player = playerObject.transform;
                x = tempx;
            }
        }

        float cameraY = (player.position.y + 2f - transform.position.y) / 10;
        if (player.position.x > transform.position.x && player.position.x > theFarestX)
        {
            transform.position = new Vector3(player.position.x, transform.position.y + cameraY, transform.position.z);
            theFarestX = player.position.x;
        }
        else transform.position = new Vector3(transform.position.x, transform.position.y + cameraY, transform.position.z);//Po co ten else
    }
}
