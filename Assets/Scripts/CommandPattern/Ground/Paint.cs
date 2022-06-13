using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
 public class Paint : MonoBehaviour
 {

     private ColorChange _colorChange;
     private ColorCommand _command;
     [SerializeField] private Color _color;

     private void Awake()
     {
         _colorChange = GetComponent<ColorChange>();
         _command = new ColorCommand(_colorChange,_color);
     }


     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
           _command.Execute();
           print(other.tag);
         }
     }

     private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Back"))
         {
           _command.Undo();
         }
     }
 }

}