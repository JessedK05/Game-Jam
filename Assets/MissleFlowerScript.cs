using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleFlowerScript : MonoBehaviour
{
    public GameObject missle;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Destroy(Instantiate(missle,new Vector3(transform.position.x, transform.position.y, -3), Quaternion.identity),2);
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(spawn());
    }
}
