using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadAumentada : MonoBehaviour
{
    public float gravity = 2f;
    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * gravity, ForceMode.Acceleration);
    }
}
