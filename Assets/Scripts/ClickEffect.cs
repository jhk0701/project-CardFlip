using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public GameObject clickEffect;
    Queue<GameObject> _instEffects = new Queue<GameObject>();

    bool _isTesting = false;
    int _clickPerSec = 0;

    void Start()
    {
        // click per sec : 8~8.33333
        for (int i = 0; i < 10; i++)
        {
            GameObject particle = Instantiate(clickEffect, transform);
            particle.SetActive(false);
            _instEffects.Enqueue(particle);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SpawnParticle();
        }

        if(_isTesting && Input.GetMouseButtonUp(0))
            _clickPerSec++;
    }

    void SpawnParticle()
    {
        Vector3 pos;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            // GameObject particle = Instantiate(clickEffect, hit.point, Quaternion.identity);
            // Destroy(particle, 1f);
            pos = hit.point;
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            // GameObject particle = Instantiate(clickEffect, worldPosition, Quaternion.identity);
            // Destroy(particle, 1f);
            pos = worldPosition;
        }
            
        GameObject particle = _instEffects.Dequeue();
        _instEffects.Enqueue(particle);

        particle.SetActive(true);
        particle.transform.position = pos;
    }

    [ContextMenu("Test")]
    public void Test(){
        Invoke("StartTest", 1f);
    }

    void StartTest(){
        Debug.Log("Start Test!");
        _clickPerSec = 0;
        _isTesting = true;
        Invoke("EndTest", 3f);
    }

    void EndTest(){
        Debug.Log($"Test is end! cps : {_clickPerSec / 3f}");
        // 8 ~ 8.333333
        _isTesting = false;
    }
}
