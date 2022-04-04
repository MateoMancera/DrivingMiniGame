using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoSpikeball : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Piso Gatillo");
            GameObject.FindWithTag("Spikeball").GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
