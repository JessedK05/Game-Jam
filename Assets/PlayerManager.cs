using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI bananaText;

    public int TotalBananas = 0;


    private void Update()
    {
        bananaText.text = "X " + TotalBananas.ToString();
    }
}
