using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform _unit;
    private Vector3 _direction;
    

    public MoveCommand(Transform unit, Vector3 direction)
    {
        _unit = unit;
        _direction = direction;
    }
    
    public void Execute()
    {
        _unit.position += _direction * 0.1f;
        
    }

    public void Undo()
    {
        _unit.position -= _direction * 0.1f;
    }
}