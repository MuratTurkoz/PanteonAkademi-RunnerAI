using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text="Score : "+ score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }

    }
    public void AddCoin()
    {
        score++;
        coinText.text ="Score : "+ score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
