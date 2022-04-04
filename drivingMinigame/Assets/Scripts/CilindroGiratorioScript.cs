using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroGiratorioScript : MonoBehaviour
{
    /*GBW*/

    public float _fVelocidad = 75f;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, _fVelocidad) * Time.deltaTime);       //El cilindro gira continuamente sobre su eje Z
    }
}
