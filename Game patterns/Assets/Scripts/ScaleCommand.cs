using UnityEngine;

public class ScaleCommand:ICommand
{
    private Transform _unit;
    private Vector3 _direction;

    public ScaleCommand(Transform unit, Vector3 direction)
    {
        _unit = unit;
        _direction = direction;
    }
    public void Execute()
    {
        _unit.localScale += 0.5f * _direction;
    }

    public void Undo()
    {
        _unit.localScale -= 0.5f * _direction;
    }
}