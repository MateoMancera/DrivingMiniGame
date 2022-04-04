using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public Rigidbody sphereRigidBody;

    public float forwardAccel = 8f, reverseAccel = 4f, turnStrength = 180f, gravityForce = 10f, dragOnGround = 3;

    private float speedInput, turnInput;

    public bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    public Transform ruedaIzq, ruedaDer;

    public float maxWheelTurn;

    public ParticleSystem[] dustTrails;
    public float maxEmission = 25f;
    public float emissionRate;

    public bool isMoving;
    public float turnStopThreshold = 0.75f;

    public float multiplier = 2;

    public Vector3 initialpos;

    public bool allowControl;

    // Start is called before the first frame update
    void Start()
    {
        sphereRigidBody.transform.parent = null;
        initialpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        turnInput = 0f;

        if (allowControl)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
            }

            turnInput = Input.GetAxis("Horizontal");

        }


        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

        transform.position = new Vector3(sphereRigidBody.transform.position.x, sphereRigidBody.transform.position.y - 0.5f, sphereRigidBody.transform.position.z);

        ruedaIzq.localRotation = Quaternion.Slerp(ruedaIzq.localRotation, Quaternion.Euler(ruedaIzq.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, ruedaIzq.localRotation.eulerAngles.z), Time.deltaTime * 4) ;
        ruedaDer.localRotation = Quaternion.Slerp(ruedaDer.localRotation, Quaternion.Euler(ruedaDer.localRotation.eulerAngles.x, (turnInput * maxWheelTurn), ruedaDer.localRotation.eulerAngles.z), Time.deltaTime * 4);
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, Time.deltaTime * 4); 
        }

        Vector2 rbVelocity = new Vector2(sphereRigidBody.velocity.x, sphereRigidBody.velocity.z);
        isMoving = Vector2.Distance(rbVelocity, Vector2.zero) > turnStopThreshold;

        emissionRate = 0;
        if (isMoving)
        {
            emissionRate = maxEmission;
        }

        if (grounded) {
            sphereRigidBody.drag = dragOnGround;

            if (Mathf.Abs(speedInput) > 0)
            {
                sphereRigidBody.AddForce(transform.forward * speedInput);

            }
        }
        else
        {
            sphereRigidBody.drag = 0.1f;

            sphereRigidBody.AddForce(Vector3.up * -gravityForce * 100f); ;
        }

        foreach(ParticleSystem particle in dustTrails)
        {
            var emissionModule = particle.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }

   
}
