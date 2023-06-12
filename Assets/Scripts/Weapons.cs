using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
          {
            Shoot();
          }
    }

    private void Shoot()
  {
    if (ammoSlot.GetCurrentAmmo() > 0)
    {
    PlayMuzzleFlash();
    ProccessRaycast();
    ammoSlot.ReduceCurrentAmmo();
    }
  }

  private void PlayMuzzleFlash()
  {
    muzzleFlash.Play();
  }

  private void ProccessRaycast()
  {
    RaycastHit hit;
    if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
    {
      CreatHitImpact(hit);
      EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
      if (target == null) return;
      target.TakeDamage(damage);
    }
    else
    {
      return;
    }
  }

  private void CreatHitImpact(RaycastHit hit)
  {
    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    Destroy(impact, .1f);
  }
}
