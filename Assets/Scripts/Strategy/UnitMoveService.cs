using System;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitMoveService : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _stealSpeed;

    [Header("Keys")] 
    [SerializeField] private KeyCode _moveKey;
    [SerializeField] private KeyCode _runKey;
    [SerializeField] private KeyCode _stealKey;

    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveKey) && Input.GetKey(_runKey) && !Input.GetKey(_stealKey))
        {
            _unit.Move(new Run(_runSpeed));
        }
        else if (Input.GetKey(_stealKey) && Input.GetKey(_moveKey) && !Input.GetKey(_runKey))
        {
            _unit.Move(new Steal(_stealSpeed));
        }
        else if (Input.GetKey(_moveKey))
        {
            _unit.Move(new Walk(_walkSpeed));
        }
    }
}
