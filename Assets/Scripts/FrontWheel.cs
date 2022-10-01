using System.Collections;
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
        maxTorque = CarController.instance.maxTorque;
    }

    // Update is called once per frame
    void Update()
    {
        fuel = CarController.instance.currentFuel;
        TorqueControl();
        currentAngularVelocity = -frontWheel.angularVelocity;      //angular velocity in degrees per second //  degrees/second     //  RPM = (degree / 360) * 60
        m_Forward = CarController.instance.isMovingForward;
        m_Backward = CarController.instance.isMovingBackward;
    }

    private void FixedUpdate()
    {
        Move();
        
    }
    void Move()
    {
        if (fuel > 0)
        {
            //Application of torque to the wheel
            //m_Backward is used for button inputs
            //m_Forward is used for button inputs
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
        //This function is controlling the torque which is applying to the wheel

        if (m_Forward || Input.GetKey(KeyCode.RightArrow))
        {
            //m_Forward is used for gas button input
            maxAngularVelocity = 3000;      //speed of the car depends on maxAngularVelocity of the wheel

            //below is the logic of controlling torque
            //torque will be maximum on 0 angularVelocity
            if (currentAngularVelocity >= 0 && currentAngularVelocity <= maxAngularVelocity)
            {
                forwardTorque = maxTorque * (1 - currentAngularVelocity / maxAngularVelocity);
                //output torque is continuously variable
            }
            //torque will be zero on maxAngularVelocity
            else if (currentAngularVelocity > maxAngularVelocity)
            {
                forwardTorque = 0;
            }
            //when the car is in reverse and we want to move forward
            else if (currentAngularVelocity < 0)
            {
                forwardTorque = maxTorque;
            }
        }

        if (m_Backward || Input.GetKey(KeyCode.LeftArrow))
        {
            //m_Backward is used for brake button input
            maxAngularVelocity = -1500;   //for backward speed use negative value

            if (currentAngularVelocity < 0 && currentAngularVelocity >= maxAngularVelocity)
            {
                backwardTorque = maxTorque * (1 - currentAngularVelocity / maxAngularVelocity);
            }
            else if (currentAngularVelocity < maxAngularVelocity)
            {
                backwardTorque = 0;
            }
            //when the car is moving forward and we want to brake
            else if (currentAngularVelocity > 0)
            {
                backwardTorque = maxTorque;
            }
        }

    }
}
