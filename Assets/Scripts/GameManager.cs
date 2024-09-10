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

    public Card selectedCard;

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

    public void SelectCard(Card c){
        
        if(selectedCard == null)
        {
            selectedCard = c;
            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Touch);
        }
        else{
            if(c.index.Equals(selectedCard.index)){
                // match
                selectedCard.DestroyCard();
                c.DestroyCard();

                ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Success);
            }
            else{
                // not match
                selectedCard.CloseCard();
                c.CloseCard();

                ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Fail);
            }

            selectedCard = null;
        }
    }

}