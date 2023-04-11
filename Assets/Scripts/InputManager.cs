using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public List<GameObject> BananaTrees = new List<GameObject>();
    public List<GameObject> Plants = new List<GameObject>();

    public PlayerManager player;

    public bool inStore = false;
    public bool isPlacing = false;
    public int currentIPlacing = 0;
    GameObject placeHolder;

    public GameObject Store;

    public List<GameObject> plantsForShop = new List<GameObject>();
    public List<GameObject> placeHolders = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inStore)
            {
                inStore = false;
                Store.SetActive(false);
            }
            else
            {
                inStore = true;
                Store.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 pos = GetComponent<SelectorScript>().selector.transform.position;
            if (isPlacing)
            {
                bool canPlace = true;
                if(BananaTrees.Count != 0)
                {
                    for (int i = 0; i < BananaTrees.Count; i++)
                    {
                        Debug.Log(BananaTrees.Count);
                        Vector2 bananaPos = BananaTrees[i].transform.position;
                        if (bananaPos == pos)
                        {
                            canPlace = false;
                            i = BananaTrees.Count;
                        }
                    }
                }
                if(Plants.Count != 0)
                {
                    for (int i = 0; i < Plants.Count; i++)
                    {
                        Vector2 plantsPos = Plants[i].transform.position;
                        if (plantsPos == pos)
                        {
                            canPlace = false;
                            i = Plants.Count;
                        }
                    }
                }
                if (canPlace)
                {
                    if(currentIPlacing == 6)
                    {
                        BananaTrees.Add(Instantiate(plantsForShop[currentIPlacing]));
                        BananaTrees[BananaTrees.Count-1].transform.position = new Vector3(pos.x,pos.y,-2f);
                    }
                    else
                    {
                        Plants.Add(Instantiate(plantsForShop[currentIPlacing]));
                        Plants[Plants.Count-1].transform.position = new Vector3(pos.x, pos.y, -2f);
                    }
                    Destroy(placeHolder);
                    currentIPlacing = 0;
                    isPlacing = false;
                }
            }
            else
            {
                if (inStore)
                {
                    player = GetComponent<PlayerManager>();

                    if (pos == new Vector2(-0.5f, 0.5f))
                    {
                        if (player.TotalBananas >= 15)
                        {
                            player.TotalBananas -= 15;
                            buy(0);
                        }
                    }
                    if (pos == new Vector2(0.5f, 0.5f))
                    {
                        if (player.TotalBananas >= 25)
                        {
                            player.TotalBananas -= 25;
                            buy(1);
                        }
                    }
                    if (pos == new Vector2(1.5f, 0.5f))
                    {
                        if (player.TotalBananas >= 15)
                        {
                            player.TotalBananas -= 15;
                            buy(2);
                        }
                    }
                    if (pos == new Vector2(-0.5f, -0.5f))
                    {
                        if (player.TotalBananas >= 35)
                        {
                            player.TotalBananas -= 35;
                            buy(3);
                        }
                    }
                    if (pos == new Vector2(0.5f, -0.5f))
                    {
                        if (player.TotalBananas >= 20)
                        {
                            player.TotalBananas -= 20;
                            buy(4);
                        }
                    }
                    if (pos == new Vector2(1.5f, -0.5f))
                    {
                        if (player.TotalBananas >= 15)
                        {
                            player.TotalBananas -= 15;
                            buy(5);
                        }
                    }
                    if (pos == new Vector2(0.5f, -1.5f))
                    {
                        if (player.TotalBananas >= 10)
                        {
                            player.TotalBananas -= 10;
                            buy(6);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < BananaTrees.Count; i++)
                    {
                        Vector2 bananaPos = BananaTrees[i].transform.position;
                        if (bananaPos == pos)
                        {
                            BananaTrees[i].GetComponentInChildren<bananaScript>().getBananas();
                        }
                    }
                }
            }
        }
    }


    void buy(int i)
    {
        inStore = false;
        isPlacing = true;
        Store.SetActive(false);

        placeHolder = Instantiate(placeHolders[i], transform.parent = GetComponent<SelectorScript>().selector.transform);
        placeHolder.transform.localPosition = new Vector3(0, 0, 2);
        currentIPlacing = i;
    }
}
