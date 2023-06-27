using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    public Text[] namesTxt;
    public string a, b, c;

    private void Update()
    {
        namesTxt[0].text = a;
        namesTxt[1].text = b;
        namesTxt[2].text = c;
    }
}