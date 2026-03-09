using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SummonCard : MonoBehaviour
{
    public Image BlackImage;

    public GameObject button;

    private GameObject treeManager;
    private TutorialSummon tutorialSummon;

    public void Start()
    {
        treeManager = GameObject.FindGameObjectWithTag("TreeManager");
        tutorialSummon = FindFirstObjectByType<TutorialSummon>();
    }

    public void OpenCard()
    {
        StartCoroutine(FadeOut());
        treeManager.GetComponent<TreeManager>().opendCard += 1;
        button.SetActive(false);
        tutorialSummon.isOpendCard = true;
    }

    IEnumerator FadeOut()
    {
        float f = 1;
        while (f > 0)
        {
            f -= 0.1f;
            Color color = BlackImage.color;
            color.a = f;
            BlackImage.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
