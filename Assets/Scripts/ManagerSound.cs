using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        _audioSrcEffects[(int)sfx].Stop();
        
        _audioSrcEffects[(int)sfx].clip = _clips[(int)sfx];

        _audioSrcEffects[(int)sfx].Play();
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
