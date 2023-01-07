using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;
    PlayerController playerController;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController=GetComponent<PlayerController>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Lose();
        }
    }

    void Lose()
    {

        GameManager.instance.isGameOver=true;
        playerController.BackReturn();
        GetComponent<Animate>().LoseAnimation();
        //playerController.SetRunSpeed(0);
        playerController.SetLose(true);
        //gameManager.ReLoad();
        //Destroy(gameObject);
    }


}
