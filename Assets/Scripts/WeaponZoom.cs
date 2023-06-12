using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
   [SerializeField] Camera fpsCamera;
   [SerializeField] float zoomOutFOV = 60f;
   [SerializeField] float zoomInFOV = 20f;
}
