using System.Collections;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp;
    private float currentHp;
    private bool isDie = false;
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;
    public bool isBurn = false;
    public bool isPosion = false;
    public GameObject burnEffect;
    public GameObject poisonEffect;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    private void Awake()
    {
        currentHp = maxHp;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isBurn == true)
        {
            burnEffect.SetActive(true);
        }
        else if (isBurn == false)
        {
            burnEffect.SetActive(false);
        }

        if (isPosion == true)
        {
            poisonEffect.SetActive(true);
        }
        else if (isPosion == false)
        {
            poisonEffect.SetActive(false);
        }
        
    }

    public void TakeDamage(float damage)
    {
        if (isDie == true) return;

        currentHp -= damage;

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if (currentHp <= 0)
        {
            isDie = true;
            enemy.Ondie(EnemyDestroyType.Kill);
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = spriteRenderer.color;

        color.a = 0.4f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(0.1f);

        color.a = 1.0f;
        spriteRenderer.color = color;
    }
}
