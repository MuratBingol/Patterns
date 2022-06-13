using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
 public class ColorChange : MonoBehaviour
 {

     private Material _material;
     
     private void Awake()
     {
         _material = GetComponent<MeshRenderer>().material;
     }

     public void ChangeColor(Color newColor)
     {
         _material.color = newColor;
     }

     public Color GetColor()
     {
         return _material.color;
     }
 }

}