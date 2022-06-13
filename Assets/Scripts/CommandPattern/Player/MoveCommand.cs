using System.Collections;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

namespace Example
{
 public class MoveCommand : ICommand
 {

     private MoveControl _obj;
     private Vector3 _target;
     private Stack<Vector3> _positions;
   

     public MoveCommand(MoveControl obj,Vector3 target)
     {
         _positions = new Stack<Vector3>();
         _target=target;
         _obj = obj;
       
     }
     
     public void Execute()
     {
         var position = _obj.transform.position;
         _positions.Push(position);
         _obj.Move(position+_target);
     }

     public void Undo()
     {
         if (_positions.Count==0) return;
         _obj.Move(_positions.Pop());
     }
 }

}