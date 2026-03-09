using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;
    [SerializeField]
    private float maxHp = 20;
    private float currentHp;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    public ChapterClear chapterClear;
    public GameObject faildPanel;

    private void Awake()
    {
        currentHp = maxHp;
    }

    private void Update()
    {
        Faild();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if (currentHp <= 0)
        {

        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }
    }

    public void Faild()
    {
        if (currentHp <= 0)
        {
            faildPanel.SetActive(true);
            chapterClear.isFaild = true;
        }
    }
}
