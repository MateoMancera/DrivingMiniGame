using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkObstacles : MonoBehaviour
{

    public float multiplier;
    public Vector3 initialpos;
    public GameObject carObject;
    public Image crossFadeImage;

    public Image gameOver;
    public Image imgVictory;
    public GameObject[] vidas;
    public int vida;
    public GameObject soundLose;
    public GameObject soundWin;
    public GameObject soundGameOver;

    // Start is called before the first frame update
    void Start()
    {
        carObject.GetComponent<carController>().allowControl = false;

        gameOver.CrossFadeAlpha(0, 0.01f, false);
        vida = vidas.Length-1;

        initialpos = transform.position;
        crossFadeImage.enabled = true;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            imgVictory.CrossFadeAlpha(0, 0.01f, false);

        }
        else
        {
            imgVictory.enabled = true;

            imgVictory.CrossFadeAlpha(0, 1, false);

        }



    }
    //Check Obstacles
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision detectada");
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Colision obstaculo");
            Debug.Log("collision.rigidbody.velocity = " + collision.rigidbody.velocity);
            //gameObject.GetComponent<Rigidbody>().AddForce(collision.rigidbody.velocity * multiplier*1000);
        }
    }

    public void respawn()
    {
        vida--;
        validateLive();
        StartCoroutine(resPawnAction());
    }

    public void timeGameOver()
    {
        crossFadeImage.CrossFadeAlpha(1, 0.5f, false);
        gameOver.CrossFadeAlpha(1, 0.5f, false);
        carObject.GetComponent<carController>().allowControl = false;
        transform.position = initialpos;
        transform.rotation = Quaternion.identity;
        carObject.transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        StartCoroutine(callRestartGame());
    }

    public IEnumerator callRestartGame()
    {
        yield return new WaitForSeconds(3);
        Destroy(GameObject.Find("BackgroundAudio"));
        GameObject.Find("sceneManager").GetComponent<sceneManager>().restartGame();
        Destroy(GameObject.Find("sceneManager"));

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado");

        // Validar si el carro pasa la meta
        if (other.name == "meta")
        {
            imgVictory.CrossFadeAlpha(1, 0.5f, false);
            soundWin.GetComponent<AudioSource>().Play();
            carObject.GetComponent<carController>().allowControl = false;
            crossFadeImage.CrossFadeAlpha(1, 0.5f, false);
            StartCoroutine(llamarCambioEscena());
        }

        if (other.CompareTag("DeathZone"))
        {
            Debug.Log("Trigger deathzone");
            soundLose.GetComponent<AudioSource>().Play();

            respawn();
        }
        if (other.CompareTag("PisoGatillo"))
        {
            GameObject.FindWithTag("Spikeball").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (other.CompareTag("PisoGatillo2"))
        {
            GameObject.FindWithTag("Spikeball2").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindWithTag("Spikeball3").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindWithTag("Spikeball4").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindWithTag("Spikeball5").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (other.CompareTag("PisoGatillo3"))
        {
            Debug.Log("Animacion Escudo 1");
            GameObject.FindWithTag("Escudo1").GetComponent<Animation>().Play("EscudoAnimation");
        }
        if (other.CompareTag("PisoGatillo4"))
        {
            GameObject.FindWithTag("Escudo2").GetComponent<Animation>().Play("EscudoAnimation2");
        }
        if (other.CompareTag("PisoGatillo5"))
        {
            GameObject.FindWithTag("Escudo3").GetComponent<Animation>().Play("EscudoAnimation3");
        }
        if (other.CompareTag("PisoGatillo6"))
        {
            GameObject.FindWithTag("Escudo4").GetComponent<Animation>().Play("EscudoAnimation4");
        }
    }

    public IEnumerator llamarCambioEscena()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("sceneManager").GetComponent<sceneManager>().loadNextLevel();
    }

    public IEnumerator resPawnAction()
    {
        if (validateLive())
        {
            crossFadeImage.CrossFadeAlpha(1, 0.5f, false);
            carObject.GetComponent<carController>().allowControl = false;
            yield return new WaitForSeconds(0.5f);
            transform.position = initialpos;
            transform.rotation = Quaternion.identity;
            carObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
            crossFadeImage.CrossFadeAlpha(0, 0.5f, false);
            yield return new WaitForSeconds(1f);
            carObject.GetComponent<carController>().allowControl = true;
        }
        else
        {
            crossFadeImage.CrossFadeAlpha(1, 0.5f, false);
            carObject.GetComponent<carController>().allowControl = false;
            yield return new WaitForSeconds(0.5f);
            transform.position = initialpos;
            transform.rotation = Quaternion.identity;
            carObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            StartCoroutine(callRestartGame());

        }


    }

    public bool validateLive()
    {
        bool isAlive = true;

        for (int i = 0; i<vidas.Length; i++)
        {
            vidas[i].GetComponent<Image>().enabled = true;
            if (i>vida)
            {
                vidas[i].GetComponent<Image>().enabled = false;

            }
        }        
        if (vida < 0)
        {
            gameOver.CrossFadeAlpha(1, 0.01f, false);
            soundGameOver.GetComponent<AudioSource>().Play();
            isAlive = false;
        }

        return isAlive;
    }
}
