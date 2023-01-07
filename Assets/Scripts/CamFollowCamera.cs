using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] float sSpeed=10f;
    [SerializeField] Vector3 dist;
    [SerializeField] Transform lookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position,dPos,sSpeed*Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget);
    }
}
