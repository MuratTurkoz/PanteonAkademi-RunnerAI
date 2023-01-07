using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float runSpeed = 3f;
    [SerializeField]  float xSpeed;
    [SerializeField] float xMin = -3.5f;
    [SerializeField] float xMax = 3.5f;
    [SerializeField] int backReturn = 180;
    [SerializeField] bool isLose = false;
    //Vector3 newPos = new Vector3(0, 0, 1);
    //[SerializeField] float turnSpeed = 0.1f;
    float newXPos;
    float touchDelta;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        //Debug.Log(runSpeed);
        if (!isLose)
        {


        }

    }
    void Run()
    {
        //transform.position += newPos*runSpeed*Time.deltaTime;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            //Debug.Log(touchDelta);
        }
        else if (Input.GetMouseButton(0))
        {
            touchDelta = Input.GetAxis("Mouse X");

        }
        else
        {
            touchDelta = 0;
        }

        newXPos = transform.position.x + xSpeed * touchDelta * Time.deltaTime;

        //if (newXPos<=xMax&&newXPos>=xMin)
        //{
        //    Vector3 pos = new Vector3(newXPos, transform.position.y, transform.position.z + runSpeed * Time.deltaTime);
        //    transform.position = pos;
        //}
        //Yukarýdaki de olur.
        newXPos = Math.Clamp(newXPos, xMin, xMax);
        Vector3 pos = new Vector3(newXPos, transform.position.y, transform.position.z + runSpeed * Time.deltaTime);
        transform.position = pos;
    }
    public void SetRunSpeed(float val)
    {
        runSpeed = val;
    }
    public void BackReturn()
    {
        transform.Rotate(Vector3.down * backReturn);
    }
    public void SetLose(bool _isLose)
    {
        isLose = _isLose;
    }
}
