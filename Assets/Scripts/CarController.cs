using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float maxTorque = 5f;
    public float rotationalTorque = 5;
    public Vector3 speed;
    public float fuel = 1;
    [HideInInspector] public float currentFuel;
    public Text scoreText;
    [HideInInspector] public bool isMovingForward = false;
    [HideInInspector] public bool isMovingBackward = false;
    Rigidbody2D rb;

    public static CarController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentFuel = fuel;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        speed = rb.velocity;
        
    }
    private void FixedUpdate()
    {
        if(currentFuel > 0)
        {
            currentFuel -= 0.1f;
        }
        RotateCar();
        scoreText.text = ((int)currentFuel).ToString();
        
    }

    void RotateCar()    //This Rotates the car on land and in air
    {
        if(currentFuel > 0)
        {
            if (isMovingBackward || Input.GetKey(KeyCode.LeftArrow))     //isMovingBackward is used for button Inputs
            {
                //Clockwise rotation
                GetComponent<Rigidbody2D>().AddTorque(-rotationalTorque);
            }
            if (isMovingForward || Input.GetKey(KeyCode.RightArrow))    //isMovingForward is used for button Inputs
            {
                //anticlockwise rotation
                GetComponent<Rigidbody2D>().AddTorque(rotationalTorque);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            currentFuel = fuel;     //Refueling car
        }
    }
}    
