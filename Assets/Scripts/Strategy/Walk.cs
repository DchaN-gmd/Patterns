using UnityEngine;

public class Walk : IMove
{
    private float _speed;

    public Walk(float speed)
    {
        _speed = speed;
    }

    public void Move()
    {
        Debug.Log($"Move with {_speed} speed");
    }
}