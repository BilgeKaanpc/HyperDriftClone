using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class carController : MonoBehaviour
{

    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float angle;
    [SerializeField] float traction;

    public Transform lw, rw;
    Vector3 _rotVec;
    float drugAmount = 0.98f;
    Vector3 _moveVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * angle * Time.deltaTime * _moveVec.magnitude);
        _moveVec *= drugAmount;
        _rotVec += new Vector3(0, Input.GetAxis("Horizontal")*2, 0);
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);
        _moveVec = Vector3.Lerp(_moveVec.normalized,transform.forward,traction * Time.deltaTime) * _moveVec.magnitude;
        _rotVec = Vector3.ClampMagnitude(_rotVec, 30);

        Debug.Log(Input.GetAxis("Horizontal").ToString());

        if(Input.GetAxis("Horizontal") == 0)
        {
            if(_rotVec.y > 0)
            {
                _rotVec += new Vector3(0, -1, 0);

            }
            else if(_rotVec.y < 0)
            {
                _rotVec -= new Vector3(0, -1, 0);

            }
            else
            {

            }

        }

        lw.localRotation = Quaternion.Euler(_rotVec);
        rw.localRotation = Quaternion.Euler(_rotVec);
    }
}
