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
    
    [Header("Board")]
    public Board board;

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
            ManagerSound.instance.StartBgm(ManagerSound.ETypeBgm.Emergence);
        }
        else if (_time <= 0f)
        {
            RedBackground.SetActive(false);
            _time = 0f;

            Time.timeScale = 0f;
           
            GameOver(false);
        }
    }


    public void GameOver(bool isWin){
        ManagerSound.instance.StartBgm(ManagerSound.ETypeBgm.Main);

        RedBackground.SetActive(false);
        _isPlaying = false;

        _pnlGameOver.SetActive(true);
        _txtGameResult.text = isWin ? "축하합니다!\n" : "실패했어요...";
        
        if(isWin)
        {
            ManagerSound.instance.StartSfx(ManagerSound.ETypeSfx.Victory, true);

            ManagerGlobal.instance.mData.UpdateSceneClear(
                ManagerGlobal.instance.curPlayingStage,
                true);
            ManagerGlobal.instance.mData.SaveData();

            if(ManagerGlobal.instance.curPlayingStage.Equals(ManagerGlobal.instance.mData.sceneCount - 1))
                ManagerGlobal.instance.LoadScene((int)ManagerGlobal.EScene.EndingScene);
        }
    }

    public void Retry(){
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.EScene.GameScene);
        ManagerSound.instance.StartBgm(ManagerSound.ETypeBgm.Main);
    }

    public void Exit(){
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.EScene.StartScene);
    }

    
    void InitBonusTime(){
        for (int i = 0; i < 5; i++)
        {
            Text inst = Instantiate(_prefBonusTime, _tfBonusTime);
            inst.gameObject.SetActive(false);

            _instBonusTime.Enqueue(inst);
        }
    }

    public void AddTime(bool isBonus){
        int curStage = ManagerGlobal.instance.curPlayingStage;
        ManagerData.StageDifficulty dif = ManagerGlobal.instance.mData.stageDifficulties[curStage];
        float val = isBonus ? dif.bonus : dif.penalty;
        
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