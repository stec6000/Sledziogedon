using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public float speedMin = 10f;
    public float speedMax = 15f;
    public bool direction = true;

    private GameObject bulletPrefab;
    private float timeBetweenShots = 1f;
    private float timestamp = 0f;
    
	void Start () {
        bulletPrefab = Resources.Load("fishBarrel") as GameObject;

	}
	
	void Update () {
        if (Mathf.Abs(transform.rotation.z) > 0.1f)
            Destroy(gameObject);

        if (Time.time >= timestamp)
        {
            GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player") as GameObject;
            if(tempPlayer != null)
            if (Mathf.Abs(tempPlayer.transform.position.x - transform.position.x) < 15
                && Mathf.Abs(tempPlayer.transform.position.y - transform.position.y) < 15) {
                GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.transform.position = transform.position;
                if (!direction)
                    bullet.transform.rotation = Quaternion.Euler(0, 180, -90);
                else
                    bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
                bullet.transform.localScale *= 0.5f;
                Rigidbody2D rig = bullet.GetComponent<Rigidbody2D>();
                    rig.velocity = transform.TransformDirection(new Vector3((-1)*Random.Range(speedMin, speedMin), 0, 0));
                timestamp = Time.time + timeBetweenShots;
            }
        }

	}
}
