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
        ManagerSound.instance.StartBgm(ManagerSound.ETypeBgm.Main);
    }

    public void OpenStage(){
        _pnlSelectStage.SetActive(true);

        List<bool> clearedScene = ManagerGlobal.instance.playerData.clearedStage;

        int maxStage = -1;
        for (int i = 0; i < clearedScene.Count; i++)
        {
            _btnStages[i].interactable = clearedScene[i];
            if(clearedScene[i])
                maxStage = i;
        }
        
        int curStage = maxStage + 1;
        if(curStage < clearedScene.Count)
            _btnStages[curStage].interactable = true;
    }
    
    public void SelectStage(int id){
        ManagerGlobal.instance.curPlayingStage = id;
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.EScene.GameScene);
    }

    public void ClearData(){
        ManagerGlobal.instance.playerData.ClearSceneData();
    }
}
