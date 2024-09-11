using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerStart : MonoBehaviour
{
    [SerializeField] GameObject _pnlSelectStage;
    [SerializeField] List<Button> _btnStages;

    private void Start()
    {
        ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);
    }

    public void OpenStage(){
        _pnlSelectStage.SetActive(true);
        List<bool> clearedScene = ManagerGlobal.instance.playerData.clearedStage;
        for (int i = 1; i < clearedScene.Count; i++)
        {
            _btnStages[i].interactable = clearedScene[i];
        }
    }
    
    public void SelectStage(int id){


    }
}
