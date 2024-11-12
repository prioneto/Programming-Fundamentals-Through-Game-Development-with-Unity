using UnityEngine;

public abstract class EnemyAb : MonoBehaviour
{
    public int health = 50;
    public float speed = 2.0f;

    public abstract void Attack();
    public abstract void Move();
}
