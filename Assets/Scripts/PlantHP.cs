using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHP : MonoBehaviour
{
    public int Health;
    public bool isRock;

    public KeyCode yeet;
    void Start()
    {
        if (isRock == false)
        {
            Health = 4;
        }
        else if (isRock == true)
        {
            Health = 25;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(yeet) && isRock == false)
        {
            Health = -1;
        }
        else if (Input.GetKey(yeet) && isRock == true)
        {
            Health = -5;
           
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
