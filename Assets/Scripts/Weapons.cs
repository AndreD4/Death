using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
          {
            Shoot();
          }
    }

    private void Shoot()
    {
      RaycastHit hit;
      if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
      {
        Debug.Log("i hit something:" + hit.transform.name);
        //add some effects
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if(target == null) return;
        target.TakeDamage(damage);
      }
      else
      {
        return;
      }
    }
}
