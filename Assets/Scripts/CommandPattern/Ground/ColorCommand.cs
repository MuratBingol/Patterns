using System;
using System.Collections;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

namespace Example
{
 public class ColorCommand : ICommand
 {

     private ColorChange _platform;
     private Color _selectedColor;
     private Stack<Color> _colors;

     public ColorCommand(ColorChange platform,Color color)
     {
         _colors = new Stack<Color>();
         _platform = platform;
         _selectedColor = color;
     }
 
     public void Execute()
     {
         _colors.Push(_platform.GetColor());
         _platform.ChangeColor(_selectedColor);
     }

     public void Undo()
     {
         if(_colors.Count==0) return;
        _platform.ChangeColor(_colors.Pop());
     }
 }

}