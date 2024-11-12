using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 2.0f;
    private Transform player;
    public int health = 50;
    public EnemyStats stats;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Move();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemy health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy has been defeated.");
        Destroy(gameObject);
    }

    public virtual void Move()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        Debug.Log("Enemy is moving");
    }

    public virtual void Attack()
    {
        Debug.Log("Enemy Attacks");
    }

}
