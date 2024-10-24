using UnityEngine;

public class Steal : IMove
{
    private float _speed;

    public Steal(float speed)
    {
        _speed = speed;
    }

    public void Move()
    {
        Debug.Log("Steal move");
    }
}
