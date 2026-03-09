using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    private EnemyMove enemyMove;
    private Transform target;
    private float damage;

    public void Setup(Transform target, float damage)
    {
        enemyMove = GetComponent<EnemyMove>();
        this.target = target;
        this.damage = damage;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            enemyMove.MoveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        if (collision.transform != target) return;

        collision.GetComponent<EnemyHp>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
