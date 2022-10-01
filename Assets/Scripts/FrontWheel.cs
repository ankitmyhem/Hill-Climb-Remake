﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : MonoBehaviour
{
    private Rigidbody2D frontWheel;
    private float forwardTorque;
    private float backwardTorque;
    private float currentAngularVelocity;
    private float maxAngularVelocity;
    private float maxTorque;
    private float fuel;
    bool m_Forward;
    bool m_Backward;
    // Start is called before the first frame update
    void Start()
    {
        frontWheel = GetComponent<Rigidbody2D>();
        maxTorque = GameObject.FindObjectOfType<CarController>().maxTorque;
    }

    // Update is called once per frame
    void Update()
    {
        fuel = GameObject.FindObjectOfType<CarController>().currentFuel;
        TorqueControl();
        currentAngularVelocity = -frontWheel.angularVelocity;      //angular velocity in degrees per second //  degrees/second     //  RPM = (degree / 360) * 60
        m_Forward = GameObject.FindObjectOfType<CarController>().isMovingForward;
        m_Backward = GameObject.FindObjectOfType<CarController>().isMovingBackward;
    }

    private void FixedUpdate()
    {
        Move();
        
    }
    void Move()
    {
        if(fuel > 0)
        {
            if (m_Backward || Input.GetKey(KeyCode.LeftArrow))
            {
                frontWheel.AddTorque(backwardTorque * Time.deltaTime);
            }

            if (m_Forward || Input.GetKey(KeyCode.RightArrow))
            {
                frontWheel.AddTorque(-forwardTorque * Time.deltaTime);
            }
        }
    }

    void TorqueControl()
    {
        if (m_Forward || Input.GetKey(KeyCode.RightArrow))
        {
            maxAngularVelocity = 3000;

            if (currentAngularVelocity >= 0 && currentAngularVelocity <= maxAngularVelocity)
            {
                forwardTorque = maxTorque * (1 - currentAngularVelocity / maxAngularVelocity);
            }
            else if (currentAngularVelocity > maxAngularVelocity)
            {
                forwardTorque = 0;
            }
            else if (currentAngularVelocity < 0)
            {
                forwardTorque = maxTorque;
            }
        }

        if (m_Backward || Input.GetKey(KeyCode.LeftArrow))
        {
            maxAngularVelocity = -1500;

            if (currentAngularVelocity < 0 && currentAngularVelocity >= maxAngularVelocity)
            {
                backwardTorque = maxTorque * (1 - currentAngularVelocity / maxAngularVelocity);
            }
            else if (currentAngularVelocity < maxAngularVelocity)
            {
                backwardTorque = 0;
            }
            else if (currentAngularVelocity > 0)
            {
                backwardTorque = maxTorque;
            }
        }
    }
}
