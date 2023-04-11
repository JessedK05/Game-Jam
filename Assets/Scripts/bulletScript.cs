using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletspeed = 15;
    public bool isFireFlower = false;
    public bool isFreezeFlower = false;

    float LifetimeBullet = 4f;

    public GameObject bullet;
    // Start is called before the first frame update
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletspeed;

        if (LifetimeBullet > 0)
        {
            LifetimeBullet = LifetimeBullet - 1 * Time.deltaTime;

            if (LifetimeBullet < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "")
        {
            //collision.gameObject.GetComponent<MonkieHealth>().takeDamage(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "" && isFireFlower == true)
        {
            //collision.gameObject.GetComponent<MonkieHealth>().takeDamage(2);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "" && isFreezeFlower == true)
        {
            //collision.gameObject.GetComponent<MonkieHealth>().takeDamage(2);
            Destroy(gameObject);
        }

    }
}
