using System;
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

    public bool isLast;
    [SerializeField] GameObject _lock;

    public int index {
        get;
        private set;
    }

    //private Func<Card, bool> function = null;

    void Start()
    {
        anim.Play("CardIdle", -1, UnityEngine.Random.Range(0f, 1f));
    }

    public void Set(int index, Vector2 position, Sprite sprite, bool lastCard = false)
    {
        this.index = index;
        getTransform.position = position;
        SpriteRenderer spriteRenderer = front.GetComponent<SpriteRenderer>();        
        if(spriteRenderer != null)
            spriteRenderer.sprite = sprite;

        isLast = lastCard;

        if(isLast)
        {
            _lock.SetActive(isLast);
            GameManager.instance.lockedCard = this;
        }
    }

    public void OpenCard()
    {
        if(isLast == true && GameManager.instance._cardCount != 2)
        {
            Debug.Log("접근 불가");
            return;
        }
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        GameManager.instance.SelectCard(this);
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard(float delay = 3f)
    {
        if(IsInvoking("CloseCardInvoke"))
            CancelInvoke("CloseCardInvoke");

        Invoke("CloseCardInvoke", delay);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        anim.SetTrigger("restore");
        
        front.SetActive(false);
        back.SetActive(true);
    }

    public void ReleaseLock(){
        _lock.SetActive(false);
    }

}
