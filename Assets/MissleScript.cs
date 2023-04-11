using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour
{
    public float damage;
    public float speed;
    public float height;

    Vector3 startPos;
    bool goUp = true;

    private void Start()
    {
        startPos = transform.position;
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void Update()
    {
        float procent = Mathf.Abs(startPos.y - transform.position.y) / height;
        float upSpeed = 1-procent / speed;
        if(transform.position.y >= startPos.y + height)
        {
            goUp = false;
        }
        if (goUp)
        {
            transform.position += new Vector3(speed/20, upSpeed, -2) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(speed/20, 0-upSpeed, -2) * Time.deltaTime;
        }
        if(transform.position.y <= startPos.y+0.2f && !goUp)
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "")
        {
            //collision.gameObject.GetComponent<MonkieHealth>().takeDamage(damage);
            Destroy(gameObject);
        }

    }
}
