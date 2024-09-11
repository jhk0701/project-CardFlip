using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] bool _isPlaying;

    [Header("Timer")]
    public Text timeTxt;
    float _time = 0.0f;
    public GameObject RedBackground;
    [Space(10f)]
    [SerializeField] Color[] _colBonusTime;
    [SerializeField] Text _prefBonusTime;
    [SerializeField] Transform _tfBonusTime;
    Queue<Text> _instBonusTime = new Queue<Text>(); // object poolling
    

    [Header("Card")]
    public int _cardCount = 16;
    public Card selectedCard;
    public Card lockedCard; // last card

    [Header("Panel")]
    [SerializeField] GameObject _pnlGameOver;
    [SerializeField] Text _txtGameResult;

  
    [Serializable]
    public struct StageDifficulty{
        public int stage;
        public float bonus;
        public float penalty;
    }
    [Header("Difficulty")]
    public List<StageDifficulty> stageDifficulies;

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

        InitBonusTime();
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
        else if(_cardCount.Equals(2)){
            lockedCard?.ReleaseLock();
        }
    }

    void PlayEffect(Card card, string Success)
    {
        GameObject SuccessEffect = Instantiate(Resources.Load(Success), card.transform.position, Quaternion.identity) as GameObject;
        Destroy(SuccessEffect, 1f);
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
            PlayEffect(selectedCard, "Success");
            PlayEffect(c, "Success");
            selectedCard.DestroyCard();
            c.DestroyCard();

            SetCardCnt(_cardCount - 2);
            
            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Success);

            // bonus
            AddTime(stageDifficulies[ManagerGlobal.instance.curPlayingStage].bonus);
        }
        else{
            // not match
            selectedCard.anim.SetTrigger("failTrigger");
            c.anim.SetTrigger("failTrigger");
            
            selectedCard.CloseCard(0.8f);
            c.CloseCard(0.8f);

            ManagerSound.instance.StartSfx(ManagerSound.TypeSfx.Fail);

            //penalty
            AddTime(stageDifficulies[ManagerGlobal.instance.curPlayingStage].penalty);
        }

        selectedCard = null;
    }

    public void GameOver(bool isWin){
        // if(isWin)
        // {
        //     SceneManager.LoadScene(2);
        //     ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);
        //     return;
        // }
        ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);

        RedBackground.SetActive(false);
        _isPlaying = false;

        _pnlGameOver.SetActive(true);
        _txtGameResult.text = isWin ? "축하합니다!\n" : "실패했어요...";
        
        if(isWin)
        {
            ManagerGlobal.instance.playerData.UpdateSceneClear(
                ManagerGlobal.instance.curPlayingStage,
                true);
            ManagerGlobal.instance.playerData.SaveData();

            if(ManagerGlobal.instance.curPlayingStage.Equals(ManagerGlobal.instance.playerData.sceneCount - 1))
                ManagerGlobal.instance.LoadScene((int)ManagerGlobal.eScene.EndingScene);
        }
    }

    public void Retry(){
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.eScene.GameScene);
        ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);
    }

    public void Exit(){
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.eScene.StartScene);
    }

    
    void InitBonusTime(){
        for (int i = 0; i < 5; i++)
        {
            Text inst = Instantiate(_prefBonusTime, _tfBonusTime);
            inst.gameObject.SetActive(false);

            _instBonusTime.Enqueue(inst);
        }
    }

    void AddTime(float val){
        if(val.Equals(0f)) return;

        _time += val;

        Text t = _instBonusTime.Dequeue();
        _instBonusTime.Enqueue(t);
        t.gameObject.SetActive(false);

        t.text = $"{(val > 0 ? "+" : "")}{val} sec";
        t.color = _colBonusTime[Convert.ToInt16(val > 0)];
        t.gameObject.SetActive(true);
    }

}