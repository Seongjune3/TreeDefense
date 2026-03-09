using UnityEngine;

public class Slow : MonoBehaviour
{
    private TowerWeapon towerWeapon;

    private void Awake()
    {
        towerWeapon = GetComponentInParent<TowerWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        if (collision.GetComponent<EnemyMove>().isSlow == true)
        {
            return;
        }

        EnemyMove enemyMove = collision.GetComponent<EnemyMove>();

        enemyMove.MoveSpeed -= enemyMove.MoveSpeed * towerWeapon.Slow;

        collision.GetComponent<EnemyMove>().isSlow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }

        collision.GetComponent<EnemyMove>().ResetMoveSpeed();

        collision.GetComponent<EnemyMove>().isSlow = false;
    }
}
