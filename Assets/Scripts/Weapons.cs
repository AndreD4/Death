using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
          {
            Shoot();
          }
    }

    private void Shoot()
    {
      RaycastHit hit;
      Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
      Debug.Log("i hit something" + hit.transform.name);
    }
}
