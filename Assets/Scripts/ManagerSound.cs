using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSound : MonoBehaviour
{
    public static ManagerSound instance;
    public enum ETypeBgm {
        None, Main, Emergence
    }
    public enum ETypeSfx : int {
        Touch = 0, Success = 1, Fail = 2, Victory = 3
    }


    ETypeBgm _curBgm = ETypeBgm.None;
    [SerializeField] AudioSource _audioSrcMain;
    GameObject _goEffect;
    List<AudioSource> _audioSrcEffects = new List<AudioSource>();

    [Header("BGM")]
    [SerializeField] AudioClip _clipMainBgm;
    [SerializeField] AudioClip _clipEmergencyBgm;

    [Header("Effect")]
    [SerializeField] List<AudioClip> _clips;

    float pVolumeBgm{
        get { return ManagerGlobal.instance.mData.volumeBgm; }
        set {
            ManagerGlobal.instance.mData.volumeBgm = value;
            _audioSrcMain.volume = value;
            _txtBgm.text = (value * 100f).ToString("N0");
        }
    }
    
    float pVolumeSfx{
        get { return ManagerGlobal.instance.mData.volumeSfx; }
        set {
            ManagerGlobal.instance.mData.volumeSfx = value;

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
        if(_goEffect == null)
        {
            _goEffect = new GameObject("Sound Effect");
            _goEffect.transform.SetParent(transform);
        }

        for (int i = 0; i < _clips.Count; i++)
        {
            AudioSource src = _goEffect.AddComponent<AudioSource>();

            _audioSrcEffects.Add(src);
            src.playOnAwake = false;
            src.loop = false;
        }

        pVolumeBgm = ManagerGlobal.instance.mData.volumeBgm;
        pVolumeSfx = ManagerGlobal.instance.mData.volumeSfx;
    }


    public void StartBgm(ETypeBgm bgm){
        if(bgm.Equals(_curBgm))
            return;
        
        _curBgm = bgm;
        _audioSrcMain.Stop();
        switch(bgm){
            case ETypeBgm.Main :
            _audioSrcMain.clip = _clipMainBgm;
            break;

            case ETypeBgm.Emergence : 
            _audioSrcMain.clip = _clipEmergencyBgm;
            break;
        }

        _audioSrcMain.Play();
    }

    public void StartSfx(ETypeSfx sfx, bool isEmphasized = false){
        
        _audioSrcEffects[(int)sfx].clip = _clips[(int)sfx];
        if(isEmphasized)
            StartCoroutine(EmphasizeSfx(_audioSrcEffects[(int)sfx]));

        _audioSrcEffects[(int)sfx].Play();
    }

    IEnumerator EmphasizeSfx(AudioSource audioSrc){
        float origin = _audioSrcMain.volume;

        if(_audioSrcMain.volume > 0.1f)
            _audioSrcMain.volume = 0.1f;
        
        yield return new WaitForSeconds(audioSrc.clip.length - 1f);
            
         _audioSrcMain.volume = origin;
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
        ManagerGlobal.instance.mData.SaveData();
    }
}
