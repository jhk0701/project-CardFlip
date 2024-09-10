using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] bool _isPlaying;

    [Header("Timer")]
    public Text timeTxt;
    float _time = 0.0f;
    public GameObject RedBackground;

    [Header("Card")]
    [SerializeField] int _cardCount = 16;
    public Card selectedCard;

    [Header("Panel")]
    [SerializeField] GameObject _pnlGameOver;
    [SerializeField] Text _txtGameResult;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

   
    void Start()
    {   
        if(_pnlGameOver.activeInHierarchy)
            _pnlGameOver.SetActive(false);

        _isPlaying = true;
        Time.timeScale = 1.0f;
        _time = 30f;
    }

    private void Update()
    {
        if(!_isPlaying) return;

        _time -= Time.deltaTime;
        timeTxt.text = _time.ToString("N2");

        if (_time <= 10f && !RedBackground.activeInHierarchy)
        {
            RedBackground.SetActive(true);
            ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Emergence);
        }
        else if (_time <= 0f)
        {
            RedBackground.SetActive(false);
            _time = 0f;

            Time.timeScale = 0f;
           
            GameOver(false);
        }
    }

    public void SetCardCnt(int cnt){
        _cardCount = cnt;

        if(_cardCount.Equals(0)){
            // win
            GameOver(true);
        }
    }

    public void SelectCard(Card c){
        
        if(selectedCard == null)
        {
            selectedCard = c;
            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Touch);

            return;
        }

        if(c.index.Equals(selectedCard.index)){
            // match
            selectedCard.DestroyCard();
            c.DestroyCard();

            SetCardCnt(_cardCount - 2);

            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Success);
        }
        else{
            // not match
            selectedCard.CloseCard(0.5f);
            c.CloseCard(0.5f);

            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Fail);
        }

        selectedCard = null;
    }

    public void GameOver(bool isWin){
        Debug.Log($"Player is win ? {isWin}");
        RedBackground.SetActive(false);
        _isPlaying = false;

        _pnlGameOver.SetActive(true);
        _txtGameResult.text = isWin ? "축하합니다!\n팀원들의 사진" : "실패했어요...";
    }

    public void Retry(){
        SceneManager.LoadScene(1);
        ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);
    }
}