using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    [SerializeField] public Text[] namesText;
    public string a, b, c, d, e, f;
    private void Update()
    {
        namesText[0].text = a;
        namesText[1].text = b;
        namesText[2].text = c;
        namesText[3].text = d;
        namesText[4].text = e;
        namesText[4].text = f;


    }
}
