using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    [Header("Set basics for HUD")]
    public TextMeshProUGUI Text_Time;
    public GameObject Player;
    public GameObject MensajeInitial;
    public float AmountPerTime;
    public float SlowTime;


    private float Timer;
    private bool onceTime;
    private bool onceTimer;

    private void Start()
    {
        onceTimer = true;
        Time.timeScale = 1f;
        MensajeInitial.gameObject.SetActive(true);
    }
    void Update()
    {
        if(Player != null && Player.activeSelf == true)
        {
            Timer += Time.deltaTime;
            Text_Time.text = "Time: " + Timer.ToString("F2");
        }

        if (onceTimer == true)
        {
            if (Time.timeScale > 0.1)
            {
                SlowTime -= AmountPerTime;
                Time.timeScale = SlowTime;
            }
        }

        if(Time.timeScale <= 0.1)
        {
            onceTimer = false;
            onceTime = true;
        }

        if(onceTime == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MensajeInitial.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                onceTime = false;
            }
        }
    }
}
