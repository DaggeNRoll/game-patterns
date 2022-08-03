using System;
using UnityEngine;

public class InputManagerCommand : MonoBehaviour
{
    private CommandProcessor _commandProcessor;
    private Vector3 _direction;

    public event EventHandler<OnCubeMoveArgs> OnCubeMoved;
    public event EventHandler OnCubeScaled;

    public class OnCubeMoveArgs : EventArgs
    {
        public string Direction;

        public OnCubeMoveArgs(string s)
        {
            Direction = s;
        }
    }
    
    
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
            OnCubeScaled?.Invoke(this,EventArgs.Empty);
            _commandProcessor.ExecuteCommand(new ScaleCommand(transform,-Vector3.one));
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OnCubeScaled?.Invoke(this,EventArgs.Empty);
            _commandProcessor.ExecuteCommand(new ScaleCommand(transform,Vector3.one));
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnCubeMoved?.Invoke(this, new OnCubeMoveArgs("left"));
            _direction.x = -1f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnCubeMoved?.Invoke(this, new OnCubeMoveArgs("right"));
            _direction.x = 1f;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            OnCubeMoved?.Invoke(this,new OnCubeMoveArgs("up"));
            _direction.z = 1f;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            OnCubeMoved?.Invoke(this,new OnCubeMoveArgs("down"));
            _direction.z = -1f;
        }
            
        
        /*var horInput = Input.GetAxisRaw("Horizontal");
        var vertInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(horInput, 0f, vertInput);*/
        
        if(_direction!=Vector3.zero)
            _commandProcessor.ExecuteCommand(new MoveCommand(transform,_direction));
    }
}