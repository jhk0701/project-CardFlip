using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public GameObject front;
    public GameObject back;

    public Animator anim;

    private bool _hasTransform = false;

    private Transform _transform;

    private Transform getTransform {
        get
        {
            if(_hasTransform == false)
            {
                _hasTransform = true;
                _transform = transform;
            }
            return _transform;
        }
    }

    public int index {
        get;
        private set;
    }

    public void Set(int index, Vector2 position, Sprite sprite)
    {
        this.index = index;
        getTransform.position = position;
        //frontImage.sprite = sprite; 
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        //animator.SetBool("isOpen", false);
        //front.SetActive(false);
        //back.SetActive(true);
    }

}
