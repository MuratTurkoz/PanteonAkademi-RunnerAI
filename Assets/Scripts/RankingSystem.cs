using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    [SerializeField]public  float distance;
    [SerializeField] GameObject target;
    [SerializeField] public int rank;
    void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position,target.transform.position);
    }
    private void Update()
    {
        CalculateDistance();
    }

}
