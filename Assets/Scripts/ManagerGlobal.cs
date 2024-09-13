using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGlobal : MonoBehaviour
{
    public static ManagerGlobal instance;
    public int curPlayingStage = 0;
    public PlayerData playerData;

    public enum EScene : int{
        StartScene = 0,
        GameScene = 1,
        EndingScene = 2,
    }

    private void Awake()
    {
        if(instance){
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sid){
        SceneManager.LoadScene(sid);
    }

}
