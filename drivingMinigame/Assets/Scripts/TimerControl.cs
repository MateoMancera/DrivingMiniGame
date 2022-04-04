using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{

    [SerializeField]
    private GameObject timerUI;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timerUI.SetActive(true);
        timer = gameObject.GetComponent<Timer>();
        timer.startTimer();
    }

    private void startGame()
    {

    }
}
