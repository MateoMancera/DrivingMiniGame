using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour
{

    public GameObject[] countdown;
    public GameObject cortinaGeneral, cortina, instructions, carObject, timer;
    public GameObject soundBeep;
    public GameObject soundGo;
    public bool receiveKey;

    // Start is called before the first frame update
    void Start()
    {
        cortina.GetComponent<Image>().CrossFadeAlpha(0, 0.01f, false);
        instructions.GetComponent<Image>().CrossFadeAlpha(0, 0.01f, false);
        carObject.GetComponent<carController>().allowControl = false;

        for (int i = 0; i<countdown.Length;i++)
        {
            countdown[i].GetComponent<Image>().CrossFadeAlpha(0, 0.01f, false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            showInstructions();
        }
        else
        {
            StartCoroutine(countdownRoutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (receiveKey && Input.anyKey)
        {
            receiveKey = false;
            StartCoroutine(countdownRoutine());
        }
    }

    public void showInstructions()
    {
        receiveKey = true;
        cortina.GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
        instructions.GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
    }

    public IEnumerator countdownRoutine()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            instructions.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        }
        yield return new WaitForSeconds(0.5f);
        soundBeep.GetComponent<AudioSource>().Play();
        countdown[0].GetComponent<Image>().CrossFadeAlpha(1,0.5f,false);
        yield return new WaitForSeconds(0.5f);
        countdown[0].GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        soundBeep.GetComponent<AudioSource>().Play();
        countdown[1].GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        countdown[1].GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        soundBeep.GetComponent<AudioSource>().Play();
        countdown[2].GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        countdown[2].GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        soundGo.GetComponent<AudioSource>().Play();
        countdown[3].GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        countdown[3].GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        cortina.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        carObject.GetComponent<carController>().allowControl = true;
        timer.GetComponent<Timer>().startTimer();

    }
}
