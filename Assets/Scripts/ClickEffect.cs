using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public GameObject clickEffect;


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SpawnParticle();
        }
    }

    void SpawnParticle()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            GameObject particle = Instantiate(clickEffect, hit.point, Quaternion.identity);
            Destroy(particle, 1f);
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            GameObject particle = Instantiate(clickEffect, worldPosition, Quaternion.identity);
            Destroy(particle, 1f);

        }
    }
}
