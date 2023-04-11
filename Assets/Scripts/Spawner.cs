using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Prefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;


    void Start()
    {
        StartCoroutine(WaitForFunction());
        
    }


    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(7);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            
            float minTime = Time.time / 10;
            Vector3 pos = new Vector3(Random.Range(minTras, maxTras), transform.position.y, transform.position.z);
            if(Random.Range(0,10) > 7)
            {
                Instantiate(Prefab[Random.Range(0, Prefab.Length)], pos, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range((secondSpawn - minTime)-1, (secondSpawn - minTime)+1));
        }
    }
}
