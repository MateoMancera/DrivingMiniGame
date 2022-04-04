using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContinuo : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
