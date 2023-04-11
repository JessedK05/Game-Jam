using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject selector;

    private void Start()
    {
        StartCoroutine(Move());
    }

    Vector2 MovePos;

    private void Update()
    {
        if (!GetComponent<InputManager>().inStore)
        {
            CheckMoveInput();
        }
        else
        {
            CheckStoreInput();
        }
    }

    void CheckStoreInput()
    {
        Vector2 pos = selector.transform.position;

        if(pos.x >1.5 || pos.x < -0.5f || pos.y >1.5f || pos.x < -0.5f)
        {
            selector.transform.position = new Vector3(0.5f, -0.5f, -9.57f);
        }

        if (Input.GetKey(KeyCode.A) && pos.x > -0.5f || Input.GetKey(KeyCode.LeftArrow) && pos.x > -0.5f)
        {
            MovePos = new Vector2(-1, MovePos.y);
        }
        else if (Input.GetKey(KeyCode.D) && pos.x < 1.5 || Input.GetKey(KeyCode.RightArrow) && pos.x < 1.5)
        {
            MovePos = new Vector2(1, MovePos.y);
        }
        else
        {
            MovePos = new Vector2(0, MovePos.y);
        }

        if (Input.GetKey(KeyCode.W) && pos.y < 0.5f || Input.GetKey(KeyCode.UpArrow) && pos.y < 0.5f)
        {
            MovePos = new Vector2(MovePos.x, 1);
        }
        else if (Input.GetKey(KeyCode.S) && pos.y > -1.5 || Input.GetKey(KeyCode.DownArrow) && pos.y > -1.5)
        {
            MovePos = new Vector2(MovePos.x, -1);
        }
        else
        {
            MovePos = new Vector2(MovePos.x, 0);
        }
    }

    void CheckMoveInput()
    {
        Vector2 pos = selector.transform.position;

        if (Input.GetKey(KeyCode.A) && pos.x > -4.5f || Input.GetKey(KeyCode.LeftArrow) && pos.x > -4.5f)
        {
            MovePos = new Vector2(-1, MovePos.y);
        }
        else if (Input.GetKey(KeyCode.D) && pos.x < 7.5 || Input.GetKey(KeyCode.RightArrow) && pos.x < 7.5)
        {
            MovePos = new Vector2(1, MovePos.y);
        }
        else
        {
            MovePos = new Vector2(0, MovePos.y);
        }

        if (Input.GetKey(KeyCode.W) && pos.y < 3.5f || Input.GetKey(KeyCode.UpArrow) && pos.y < 3.5f)
        {
            MovePos = new Vector2(MovePos.x, 1);
        }
        else if (Input.GetKey(KeyCode.S) && pos.y > -3.5 || Input.GetKey(KeyCode.DownArrow) && pos.y > -3.5)
        {
            MovePos = new Vector2(MovePos.x, -1);
        }
        else
        {
            MovePos = new Vector2(MovePos.x, 0);
        }
    }

    public IEnumerator Move()
    {
        selector.transform.position += new Vector3(MovePos.x, MovePos.y, 0);
        if(MovePos.x == 0 && MovePos.y == 0)
        {
            yield return new WaitForSeconds(0.01f);
        }
        else
        {
            yield return new WaitForSeconds(0.15f);
        }

        StartCoroutine(Move()); 
    }
}
