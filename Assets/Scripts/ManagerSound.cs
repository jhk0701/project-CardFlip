using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour
{
     public static ManagerSound instance;

    [SerializeField] AudioSource _audioSrcMain;
    [SerializeField] AudioSource _audioSrcEffect;

    public enum TypeBgm {
        Main, Emergence
    }
    public enum TypeSfx {
        Touch, Success, Fail
    }

    [Header("BGM")]
    [SerializeField] AudioClip _clipMainBgm;
    [SerializeField] AudioClip _clipEmergencyBgm;

    [Header("Effect")]
    [SerializeField] AudioClip _clipTouch;
    [SerializeField] AudioClip _clipMatchSuccess;
    [SerializeField] AudioClip _clipMatchFail;

    public void Awake()
    {
        if(instance){
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
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

        _audioSrcEffect.Stop();
        
        switch(sfx){
            case TypeSfx.Touch :
            _audioSrcEffect.clip = _clipTouch;
            break;
            case TypeSfx.Success :
            _audioSrcEffect.clip = _clipMatchSuccess;
            break;
            case TypeSfx.Fail :
            _audioSrcEffect.clip = _clipMatchFail;
            break;
        }

        _audioSrcEffect.Play();
    }

    [ContextMenu("Test")]
    public void Test1(){
        StartSfx(TypeSfx.Touch);
        Invoke("Test2", 1f);
        Invoke("Test3", 2f);
    }

    void Test2(){
        StartSfx(TypeSfx.Success);
    }
    void Test3(){
        StartSfx(TypeSfx.Fail);
    }
}
