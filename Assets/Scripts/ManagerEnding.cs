using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerEnding : MonoBehaviour
{
    [SerializeField] Text _txtName;
    [SerializeField] Text _txtTmi;
    [SerializeField] List<Image> _imgPictures;

    [SerializeField] Button _btnNext;
    [SerializeField] Button _btnPrev;
    [SerializeField] List<Button> _btnPages;

    [Serializable]
    public struct DataTmi {
        public string name;
        public string mbti;
        public string hobby;
        public string favoriteGame;
        public Sprite[] pic;
    }

    public List<DataTmi> listTmi;

    [SerializeField] int _curPage;
    int page{
        get { return _curPage; }
        set {
            _curPage = value;
            
            if (_curPage < 0)
                _curPage = 0;
            else if(_curPage >= listTmi.Count)
                _curPage = listTmi.Count - 1;

            SetPage(_curPage);
        }
    }

    public void Next(){
        page++;
    }

    public void Prev(){
        page--;
    }

    public void GoTo(int num){
        page = num;
    }

    void SetPage(int id){
        //  button setting
        _btnPrev.interactable = !id.Equals(0);
        _btnNext.interactable = !id.Equals(listTmi.Count - 1);

        for (int i = 0; i < _btnPages.Count; i++)
            _btnPages[i].interactable = !i.Equals(id);

        // page setting
        for (int i = 0; i < _imgPictures.Count; i++)
            _imgPictures[i].sprite = listTmi[id].pic[i];

        _txtName.text = string.Format("이름 : <size=50>{0}</size>", listTmi[id].name);
        _txtTmi.text = string.Format(
            "MBTI : {0}\n취미 : {1}\n좋아하는 게임: {2}", 
            listTmi[id].mbti, listTmi[id].hobby, listTmi[id].favoriteGame);
    }

    void Start()
    {
        SetPage(0);
    }


    public void GoToGameScene(){
        ManagerGlobal.instance.LoadScene((int)ManagerGlobal.eScene.StartScene);
    }
}
