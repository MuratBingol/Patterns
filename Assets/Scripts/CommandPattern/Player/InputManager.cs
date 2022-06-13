using System;
using System.Collections;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

namespace Example
{
    public class InputManager : MonoBehaviour
    {
        private MoveControl _moveControl;
        private ICommand _commandUp,_commandDown,_commandRight,_commandLeft;
        private Stack<ICommand> _lastPositions;
        private Coroutine _coroutine;
        [SerializeField]private float _treshold;

        private void Start()
        {
            _lastPositions = new Stack<ICommand>();
            _moveControl = GetComponent<MoveControl>();
            _commandUp = new MoveCommand(_moveControl,Vector3.forward);
            _commandDown = new MoveCommand(_moveControl,Vector3.back);
            _commandRight = new MoveCommand(_moveControl,Vector3.right);
            _commandLeft = new MoveCommand(_moveControl,Vector3.left);
        }

        private void Update()
        {
            if (_coroutine!=null) return;
        
            if (Input.GetKey(KeyCode.S))
            {
               _coroutine = StartCoroutine(CommadCalled(_commandDown));
            }
                    
            if (Input.GetKey(KeyCode.W))
            {
                _coroutine = StartCoroutine(CommadCalled(_commandUp));
            }
                      
            if (Input.GetKey(KeyCode.A))
            {
                _coroutine = StartCoroutine(CommadCalled(_commandLeft));
            }
                    
            if (Input.GetKey(KeyCode.D))
            {
                _coroutine = StartCoroutine(CommadCalled(_commandRight));
            }

            if (Input.GetKey(KeyCode.R))
            {
                if (_lastPositions.Count==0) return;
                _coroutine = StartCoroutine(LastPoint());
            }
            
        }

        private IEnumerator CommadCalled(ICommand command)
        {
            yield return new WaitForSeconds(_treshold);
            command.Execute();
            _lastPositions.Push(command);
            _coroutine = null;
        }

        private IEnumerator LastPoint()
        {
            yield return new WaitForSeconds(_treshold);
            _lastPositions.Pop().Undo();
            _coroutine = null;
        }
    }
}