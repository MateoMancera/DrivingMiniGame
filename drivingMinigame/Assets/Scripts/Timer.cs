using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField]
    public int minutes;

    [SerializeField]
    public int seconds;

    private int min, sec;

    [SerializeField]
    private Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        //startTimer();
        writeTimer(minutes,seconds);
    }

    public void startTimer() {
        min = minutes;
        sec = seconds;
        writeTimer(min, sec);
        Invoke ("updateTimer", 1f);
    }

    public void stopTimer() {
        CancelInvoke();
    }

    private void updateTimer() {
        sec--;
        if (sec < 0) {
            if (min == 0) {
                GameObject.Find("SphereCar").GetComponent<checkObstacles>().vida = 0;
                GameObject.Find("SphereCar").GetComponent<checkObstacles>().timeGameOver();
                return;
            } else {
                min--;
                sec = 59;
            }
        }
        writeTimer(min, sec);
        Invoke ("updateTimer", 1f);
    }

    private void writeTimer(int m, int s) {
        string iniMin = "";
        if (m < 10) {
            iniMin = "0";
        }
        // tiene un solo dígito
        if (s < 10) {
            timerText.text = iniMin + m.ToString() + ":0" + s.ToString();
        } else {
            timerText.text = iniMin + m.ToString() + ":" + s.ToString();
        }
    }

}
