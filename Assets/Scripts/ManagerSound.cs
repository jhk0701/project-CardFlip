using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSound : MonoBehaviour
{
    public static ManagerSound instance;
    public enum TypeBgm {
        None, Main, Emergence
    }
    public enum TypeSfx : int {
        Touch = 0, Success = 1, Fail = 2, Victory = 3
    }


    TypeBgm _curBgm = TypeBgm.None;
    [SerializeField] AudioSource _audioSrcMain;
    [SerializeField] List<AudioSource> _audioSrcEffects;

    [Header("BGM")]
    [SerializeField] AudioClip _clipMainBgm;
    [SerializeField] AudioClip _clipEmergencyBgm;

    [Header("Effect")]
    [SerializeField] List<AudioClip> _clips;

    float pVolumeBgm{
        get { return ManagerGlobal.instance.playerData.volumeBgm; }
        set {
            ManagerGlobal.instance.playerData.volumeBgm = value;
            _audioSrcMain.volume = value;
            _txtBgm.text = (value * 100f).ToString("N0");
        }
    }
    
    float pVolumeSfx{
        get { return ManagerGlobal.instance.playerData.volumeSfx; }
        set {
            ManagerGlobal.instance.playerData.volumeSfx = value;

            for (int i = 0; i < _audioSrcEffects.Count; i++)
                _audioSrcEffects[i].volume = value;

            _txtSfx.text = (value * 100f).ToString("N0");
        }
    }

    [Header("Setting Windows")]
    [SerializeField] GameObject _pnlSettingWindows;
    [SerializeField] Slider _slBgm, _slSfx;
    [SerializeField] Text _txtBgm, _txtSfx;

    public void Awake()
    {
        if(!instance) 
            instance = this;
    }

    void Start()
    {
        pVolumeBgm = ManagerGlobal.instance.playerData.volumeBgm;
        pVolumeSfx = ManagerGlobal.instance.playerData.volumeSfx;
    }


    public void StartBgm(TypeBgm bgm){
        if(bgm.Equals(_curBgm))
            return;
        
        _curBgm = bgm;
        _audioSrcMain.Stop();
        switch(bgm){
            case TypeBgm.Main :
            _audioSrcMain.clip = _clipMainBgm;
            break;

            case TypeBgm.Emergence : 
            _audioSrcMain.clip = _clipEmergencyBgm;
            break;
        }

        _audioSrcMain.Play();
    }

    public void StartSfx(TypeSfx sfx){

        _audioSrcEffects[(int)sfx].Stop();
        
        _audioSrcEffects[(int)sfx].clip = _clips[(int)sfx];

        _audioSrcEffects[(int)sfx].Play();
    }


    public void ChangeVolumeBgm(float val){
        pVolumeBgm = val;
    }
    public void ChangeVolumeSfx(float val){
        pVolumeSfx = val;
    }


    public void OpenSetting(){
        _pnlSettingWindows.SetActive(true);
        _slBgm.SetValueWithoutNotify(pVolumeBgm);
        _slSfx.SetValueWithoutNotify(pVolumeSfx);
    }

    public void CloseSetting(){
        _pnlSettingWindows.SetActive(false);
        ManagerGlobal.instance.playerData.SaveData();
    }
}
