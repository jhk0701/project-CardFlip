using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOff : MonoBehaviour
{
    [SerializeField] float _delay = 1f;
    void OnEnable()
    {
        Invoke("Off", _delay);
    }
    void Off(){
        gameObject.SetActive(false);
    }
}
