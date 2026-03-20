// FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author: [FIRAT YALDIZ] | Student ID: [230446045]


using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; // degrees/second
    [SerializeField] private float yawSpeed = 45f;   // degrees/second
    [SerializeField] private float rollSpeed = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 5f; // units/second

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb ;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        // Then set rb.freezeRotation = true.
        // Why is freezeRotation needed? Answer in your PDF.
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation =  true;
    }

    void Update()
    {

        HandleRotation();
        HandleThrust();

    }

    private void HandleRotation()
    {
        // TODO (Task 3-C):
        

        // Pitch
        float upDownInput = Input.GetAxis("Vertical");
        transform.Rotate( Vector3.right * upDownInput*pitchSpeed * Time.deltaTime);
       
        // left and right rotation (yaw)
        float leftRightInput = Input.GetAxis("Horizontal");

        transform.Rotate( Vector3.up * leftRightInput *yawSpeed * Time.deltaTime) ;
        // Roll
        float rollValue = 0f ;
        if (Input.GetKey(KeyCode.Q))
        {
            rollValue = 1f; // turn left
        }
       
        else if (Input.GetKey(KeyCode.E))
        {
            rollValue = -1f; //turn right

        }
        
        transform.Rotate(Vector3.forward* rollValue * rollSpeed *Time.deltaTime);


    }

    private void HandleThrust()
    {
        
        // TODO (Task 3-D) :
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}