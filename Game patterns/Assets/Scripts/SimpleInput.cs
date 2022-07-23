using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInput : MonoBehaviour
{
    private Vector2 _input;

    private bool _isRunning;

    private Animator _animator;

    private int _horizontalMoveHash;

    private int _verticalMoveHash;

    private int _isRunningHash;

    private int _velocityHash;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _horizontalMoveHash = Animator.StringToHash("horizontal move");
        _verticalMoveHash = Animator.StringToHash("vertical move");
        _isRunningHash = Animator.StringToHash("isRunning");
        _velocityHash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
        _isRunning = Input.GetKey(KeyCode.Space);
        
        
        SetAnimatorVariables();
        HandleRotation();
    }

    void SetAnimatorVariables()
    {
        _animator.SetFloat(_velocityHash,_input.magnitude);
        _animator.SetBool(_isRunningHash,_isRunning);
    }

    void HandleRotation()
    {
        var currentPosition = transform.position;
        var positionLookAt = currentPosition + new Vector3(_input.x, 0, _input.y);
        transform.LookAt(positionLookAt);
    }
    
}
