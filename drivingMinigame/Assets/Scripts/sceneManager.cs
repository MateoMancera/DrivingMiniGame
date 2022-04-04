using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(iniciarNivel());
        }
        Debug.Log("Nombre de escena = " + SceneManager.GetActiveScene().name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextLevel()
    {
        Debug.Log("Ingreso a loadNextLevel");
        Debug.Log("Escena activa = " + SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Nombre de escena = " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("Cargar escena 1");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Cargar escena 0");
            SceneManager.LoadScene(0);
        }
        StartCoroutine(iniciarNivel());
    }

    public IEnumerator iniciarNivel()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("CrossFade").GetComponent<Image>().CrossFadeAlpha(0, 1, false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
