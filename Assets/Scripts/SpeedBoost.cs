using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3f;
    float delay = 3f;
    PlayerController playerController;
    [SerializeField] GameObject speedBoost;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        speedBoost.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            StartCoroutine("UpdateRunSpeed");
        }
        //playerController.runSpeed = firstSpeed;
    }
    IEnumerator UpdateRunSpeed()
    {
        playerController.runSpeed += speed;
        speedBoost.SetActive(true);
        yield return new WaitForSeconds(delay);//Yukarıdaki kodu 3 sn kadar çalıştırır.
        playerController.runSpeed -= speed;
        speedBoost.SetActive(false);
    }

}
