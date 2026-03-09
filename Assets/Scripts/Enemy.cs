using UnityEngine;
using System.Collections;

public enum EnemyDestroyType { Kill = 0 , Arrive }

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private EnemyMove enemyMove;
    private EnemySpawner enemySpawner;
    [SerializeField]
    private int gold = 10;

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        enemyMove = GetComponent<EnemyMove>();
        this.enemySpawner = enemySpawner;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(OnMove());
    }

    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * enemyMove.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            enemyMove.MoveTo(direction);
        }
        else
        {
            gold = 0;
            Ondie(EnemyDestroyType.Arrive);
        }
    }

    public void Ondie(EnemyDestroyType type)
    {
        enemySpawner.DestroyEnemy(type , this , gold);
    }
}