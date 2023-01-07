using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Oppenent : MonoBehaviour
{
    [SerializeField] NavMeshAgent oppenentAgent;
    [SerializeField] GameObject target;
    [SerializeField] GameObject speedBoost;
    Vector3 oppenentAgentStartPos;
    float speed = 3f;
    float delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        oppenentAgent=GetComponent<NavMeshAgent>();
        oppenentAgentStartPos = transform.position;
        speedBoost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        oppenentAgent.SetDestination(target.transform.position);
        if (GameManager.instance.isGameOver)
        {
            oppenentAgent.isStopped=true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            oppenentAgent.speed += speed;
            speedBoost.SetActive(true);
            StartCoroutine("UpdateRunSpeed");


        }
        //playerController.runSpeed = firstSpeed;
    }
    IEnumerator UpdateRunSpeed()
    {
      
        yield return new WaitForSeconds(delay);//Yukarýdaki kodu 3 sn kadar çalýþtýrýr.
        oppenentAgent.speed -= speed;
        speedBoost.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = oppenentAgentStartPos;
        }
    }
    public void OppenentStop()
    {
        oppenentAgent.speed = 0;
    }
}
