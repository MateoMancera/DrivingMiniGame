using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    public GameObject[] vidas;
    int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidas.Length;
    }

    public void validateLife()
    {
        vida --;
        if (vida > 0)
        {
            if (vida < 1)
            {
                Destroy(vidas[0].gameObject);
            } 
            else if (vida < 2)
            {
                Destroy(vidas[1].gameObject);
            }
            else if (vida < 3)
            {
                Destroy(vidas[2].gameObject);
            }
        }
    }
}
