using System;
using UnityEngine;

public class InputManagerCommand : MonoBehaviour
{
    private CommandProcessor _commandProcessor;
    private Vector3 _direction;
    
    private void Start()
    {
        _commandProcessor = new CommandProcessor();
        
    }

    private void Update()
    {
        _direction=Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _commandProcessor.UndoCommand();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            _commandProcessor.ExecuteCommand(new ScaleCommand(transform,-Vector3.one));
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _commandProcessor.ExecuteCommand(new ScaleCommand(transform,Vector3.one));
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
            _direction.x = -1f;

        if (Input.GetKeyDown(KeyCode.D))
            _direction.x = 1f;

        if (Input.GetKeyDown(KeyCode.W))
            _direction.z = 1f;

        if (Input.GetKeyDown(KeyCode.S))
            _direction.z = -1f;
        
        /*var horInput = Input.GetAxisRaw("Horizontal");
        var vertInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(horInput, 0f, vertInput);*/
        
        if(_direction!=Vector3.zero)
            _commandProcessor.ExecuteCommand(new MoveCommand(transform,_direction));
    }
}