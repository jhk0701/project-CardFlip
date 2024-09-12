using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Playing")]
    // id = stage id
    // bool = is clear
    public int sceneCount = 2;
    public List<bool> clearedStage = new List<bool>();
    const string SCENE = "Scene";

    [Header("Souond Settings")]
    public float volumeBgm;
    public float volumeSfx;
    
    void Awake()
    {
        LoadData();
    }

    void LoadData(){
        volumeBgm = PlayerPrefs.HasKey("VolumeBgm") ? PlayerPrefs.GetFloat("VolumeBgm") : 0.4f;
        volumeSfx = PlayerPrefs.HasKey("VolumeSfx") ? PlayerPrefs.GetFloat("VolumeSfx") : 1f;

        clearedStage.Clear();
        for (int i = 0; i < sceneCount; i++)
        {
            string key = $"{SCENE}-{i}";
            int val = PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : 0;
            clearedStage.Add(Convert.ToBoolean(val));
        }
    }

    public void SaveData(){
        PlayerPrefs.SetFloat("VolumeBgm", volumeBgm);
        PlayerPrefs.SetFloat("VolumeSfx", volumeSfx);

        for (int i = 0; i < clearedStage.Count; i++)
        {
            string key = $"{SCENE}-{i}";
            PlayerPrefs.SetInt(key, Convert.ToInt16(clearedStage[i]));
        }
    }

    public void UpdateSceneClear(int id, bool isClear){
        clearedStage[id] = isClear;
    }

    [ContextMenu("Clear scene play data")]
    public void ClearSceneData(){
        for (int i = 0; i < clearedStage.Count; i++)
        {
            string key = $"{SCENE}-{i}";
            clearedStage[i] = false;
            PlayerPrefs.SetInt(key, 0);
        }
    }

}
