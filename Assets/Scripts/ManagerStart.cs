using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerStart : MonoBehaviour
{
    private void Start()
    {
        ManagerSound.instance.StartBgm(ManagerSound.TypeBgm.Main);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
