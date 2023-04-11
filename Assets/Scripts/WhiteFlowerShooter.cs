using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlowerShooter : MonoBehaviour
{
    public GameObject bullet;

    public float timer = 2;
    public bool isDoubleShooter;

    void Update()
    {
        if (timer > 0 && isDoubleShooter == false)
        {
            timer = timer - 1 * Time.deltaTime;
            if (timer <= 0)
            {
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<bulletScript>();

                timer = 2;
            }
        }

        if (timer > 0 && isDoubleShooter == true)
        {
            timer = timer - 1 * Time.deltaTime;
            if (timer <= 0)
            {
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<bulletScript>();


                timer = 1;
            }
        }
    }
}
