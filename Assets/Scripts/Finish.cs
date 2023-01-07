using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Finish : MonoBehaviour
{
    int _score;
    PlayerController playerController;
    InGameRanking ig;
    private void Start()
    {
        playerController= GetComponent<PlayerController>();
        ig = FindObjectOfType<InGameRanking>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            if (ig.namesText[0].text=="Player")
            {
                PlayerFinished();

            }
            else
            {
                PlayerLost();
            }
        }
    }

    private void PlayerFinished()
    {
        playerController.BackReturn();
        //_score = GetComponent<CollectCoin>().GetScore();
        playerController.SetRunSpeed(0);
        playerController.SetLose(true);
        GetComponent<Animate>().WinAnimation();


    }
    void PlayerLost()
    {
        playerController.BackReturn();
        //_score = GetComponent<CollectCoin>().GetScore();
        playerController.SetRunSpeed(0);
        playerController.SetLose(true);
        GetComponent<Animate>().LoseAnimation();
    }
}
