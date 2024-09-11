using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSound : MonoBehaviour
{
     public static ManagerSound instance;

    [SerializeField] AudioSource _audioSrcMain;
    [SerializeField] List<AudioSource> _audioSrcEffects;

    public enum TypeBgm {
        Main, Emergence
    }
    public enum TypeSfx : int {
        Touch = 0, Success = 1, Fail = 2
    }

    [Header("BGM")]
    [SerializeField] AudioClip _clipMainBgm;
    [SerializeField] AudioClip _clipEmergencyBgm;

    [Header("Effect")]
    [SerializeField] List<AudioClip> _clips;

    [Header("Volume")]
    [Range(0f, 1f)]
    [SerializeField] float _volumeBgm;
    float pVolumeBgm{
        get { return _volumeBgm; }
        set {
            _volumeBgm = value;
            _audioSrcMain.volume = _volumeBgm;
            _txtBgm.text = (_volumeBgm * 100f).ToString("N0");
        }
    }
    
    [Range(0f, 1f)]
    [SerializeField] float _volumeSfx;
    float pVolumeSfx{
        get { return _volumeSfx; }
        set {
            _volumeSfx = value;

            for (int i = 0; i < _audioSrcEffects.Count; i++)
                _audioSrcEffects[i].volume = _volumeSfx;

            _txtSfx.text = (_volumeSfx * 100f).ToString("N0");
        }
    }

    [Header("Setting Windows")]
    [SerializeField] GameObject _pnlSettingWindows;
    [SerializeField] Slider _slBgm, _slSfx;
    [SerializeField] Text _txtBgm, _txtSfx;

    public void Awake()
    {
        if(instance){
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSetting();
    }


    public void StartBgm(TypeBgm bgm){
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
        SaveSetting();
    }

    void LoadSetting(){
        pVolumeBgm = PlayerPrefs.HasKey("VolumeBgm") ? PlayerPrefs.GetFloat("VolumeBgm") : 0.4f;
        pVolumeSfx = PlayerPrefs.HasKey("VolumeSfx") ? PlayerPrefs.GetFloat("VolumeSfx") : 1f;
    }

    void SaveSetting(){
        PlayerPrefs.SetFloat("VolumeBgm", pVolumeBgm);
        PlayerPrefs.SetFloat("VolumeSfx", pVolumeSfx);
    }
}
