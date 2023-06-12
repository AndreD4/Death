using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
   [SerializeField] Camera fpsCamera;
   [SerializeField] float zoomOutFOV = 60f;
   [SerializeField] float zoomInFOV = 20f;

   bool zoomedInToggle = false;

   private void Update()
   {
      if(Input.GetMouseButtonDown(1))
      {
        if (zoomedInToggle == false)
        {
          zoomedInToggle = true;
          fpsCamera.fieldOfView = zoomInFOV;
        }
        else
        {
          zoomedInToggle = false;
          fpsCamera.fieldOfView = zoomOutFOV;
        }
      }
   }
}
