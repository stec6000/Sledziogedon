using UnityEngine;
using System.Collections;

public class BarrelTopDown : MonoBehaviour {

    private GameObject bulletPrefab;
    private float timeBetweenShots = 1.6f;
    private float timestamp = 0f;

    void Start()
    {
        bulletPrefab = Resources.Load("fishTopDown") as GameObject;
    }

    void Update()
    {
        if (Mathf.Abs(transform.rotation.z) > 0.1f)
            Destroy(gameObject);

        if (Time.time >= timestamp)
        {
            if (Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x) < 15
                && Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y) < 15)
            {
                GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(180, 0, 0);

                bullet.transform.localScale *= 0.5f;
                timestamp = Time.time + timeBetweenShots;
            }
        }

    }
}
