using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Camera mainCamera;
    public Text timeTxt;
    public GameObject RedBackground;

    float time = 0.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

   
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 20f && time < 30f)
        {
            RedBackground.SetActive(true);
        }

        else if (time >= 30f)
        {
           RedBackground.SetActive(false);
         
            Time.timeScale = 0f;
        }
    }
}