using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GardenCreator : MonoBehaviour
{
    public int width;
    public int height;

    public Vector3 offSet;

    public GameObject tile;

    public List<Sprite> backgroundSprites = new List<Sprite>();

    private void Start()
    {
        Vector3 spawnPos = new Vector3(-(width/2)+0.5f,-(height / 2)+0.5f,0) + offSet;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tileClone =  Instantiate(tile, spawnPos , Quaternion.identity, transform.parent = GameObject.Find("Tiles").transform);
                tile.GetComponent<SpriteRenderer>().sprite = backgroundSprites[Random.Range(0,backgroundSprites.Count)];
                spawnPos += new Vector3(0, 1, 0);
            }
            spawnPos = new Vector3(spawnPos.x, -(height / 2) + 0.5f,spawnPos.z);
            spawnPos += new Vector3(1,0,0);
        }
        gameObject.transform.parent = null;
    }
}
