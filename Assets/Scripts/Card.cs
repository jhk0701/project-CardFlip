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

    public int index {
        get;
        private set;
    }

    private Func<Card, bool> function = null;

    public void Set(int index, Vector2 position, Sprite sprite, Func<Card, bool> function)
    {
        this.index = index;
        getTransform.position = position;
        SpriteRenderer spriteRenderer = front.GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
        this.function = function;
    }

    public void OpenCard()
    {
        if (function != null && function.Invoke(this) == true)
        {
            anim.SetBool("isOpen", true);
            front.SetActive(true);
            back.SetActive(false);

            GameManager.Instance.SelectCard(this);
        }
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
