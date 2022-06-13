using System.Collections;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

namespace Example
{
 public class ColorCommand : ICommand
 {
     public void Execute()
     {
         throw new System.NotImplementedException();
     }

     public void Undo()
     {
         throw new System.NotImplementedException();
     }
 }

}