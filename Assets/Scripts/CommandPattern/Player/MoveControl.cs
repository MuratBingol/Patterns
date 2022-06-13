using System;
using System.Collections;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

namespace Example
{
 public class MoveControl : MonoBehaviour
 {
     
     public void Move(Vector3 target)
     {
         transform.LookAt(target);
         transform.position=target;
     }
     
 }

}