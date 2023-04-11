using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaScript : MonoBehaviour
{
    public float[] bananaProgression = {0,0,0,0};

    public int bananasDone =  0;
    public float growRandomness;

    public List<GameObject> bananas = new List<GameObject>();

    //WOWs

    private void Start()
    {
        for (int i = 0; i < bananas.Count; i++)
        {
            bananas[i].GetComponent<SpriteRenderer>().color = new Color(0,1,0);
        }
    }

    private void Update()
    {
        for (int i = 0; i < bananas.Count; i++)
        {
            if (Random.Range(0, 5) > 3)
            {
                if (bananaProgression[i] < 100)
                {
                    bananaProgression[i] += Random.Range(0, growRandomness * (i+1 * 10))/2 * Time.deltaTime;
                }
                else if (bananaProgression[i] < 150)
                {
                    bananas[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                    bananasDone+=5;
                    bananaProgression[i] = 200;
                }
            }
        }
    }

    public void getBananas()
    {
        FindObjectOfType<PlayerManager>().TotalBananas += bananasDone;
        bananasDone = 0;
        for (int i = 0; i < bananaProgression.Length; i++)
        {
            if(bananaProgression[i] > 150)
            {
                bananas[i].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                bananaProgression[i] = 0;
            }
        }
    }
}
