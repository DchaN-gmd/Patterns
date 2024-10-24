using UnityEngine;

public class Unit : MonoBehaviour
{
    public void Move(IMove move)
    {
        move.Move();
    }
}
