using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ChapterManager : MonoBehaviour
{
    [System.Serializable]
    public class Chapters
    {
        public GameObject clearText;
        public GameObject notOpend;
    }
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;
    public GameObject chapter4;
    
    [SerializeField]
    private List<Chapters> chapterList = new List<Chapters>();

    private void Start()
    {
        CheckClearStage();
    }
    
    public void CheckClearStage()
    {
        for (int i = 0; i < chapterList.Count && i < GameManager.Instance.clearStages.Length; i++)
        {
            bool isCleared = GameManager.Instance.clearStages[i];

            bool isUnlocked = false;

            if (i == 0)
            {
                // 첫 번째 스테이지는 항상 열려 있음
                isUnlocked = true;
            }
            else
            {
                // 이전 스테이지가 클리어되면 현재 스테이지 잠금 해제
                isUnlocked = GameManager.Instance.clearStages[i - 1];
            }

            chapterList[i].clearText.SetActive(isCleared);
            chapterList[i].notOpend.SetActive(!isUnlocked);
        }
    }

    public void OnChapter2()
    {
        chapter1.SetActive(false);

        chapter2.SetActive(true);
    }

    public void OnChapter3()
    {
        chapter2.SetActive(false);

        chapter3.SetActive(true);
    }

    public void OnChapter4()
    {
        chapter3.SetActive(false);

        chapter4.SetActive(true);
    }

    public void OffChapterPanel()
    {
        chapter1.SetActive(false);
        chapter2.SetActive(false);
        chapter3.SetActive(false);
        chapter4.SetActive(false);
    }

    public void BackChapter1()
    {
        chapter1.SetActive(true);

        chapter2.SetActive(false);
    }

    public void BackChapter2()
    {
        chapter2.SetActive(true);

        chapter3.SetActive(false);
    }

    public void BackChapter3()
    {
        chapter3.SetActive(true);

        chapter4.SetActive(false);
    }

    //////////////////////////////////////////////////////////////////////////

    public void chapter1_1()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("1-1");
        GameManager.Instance.nowStage = 1;
    }

    public void chapter1_2()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("1-2");
        GameManager.Instance.nowStage = 2;
    }

    public void chapter1_3()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("1-3");
        GameManager.Instance.nowStage = 3;
    }

    public void chapter2_1()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("2-1");
        GameManager.Instance.nowStage = 4;
    }

    public void chapter2_2()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("2-2");
        GameManager.Instance.nowStage = 5;
    }

    public void chapter2_3()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("2-3");
        GameManager.Instance.nowStage = 6;
    }

    public void chapter3_1()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("3-1");
        GameManager.Instance.nowStage = 7;
    }

    public void chapter3_2()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("3-2");
        GameManager.Instance.nowStage = 8;
    }

    public void chapter3_3()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("3-3");
        GameManager.Instance.nowStage = 9;
    }

    public void chapter4_1()
    {
        if (GameManager.Instance.equipTrees.Count < 1) return;
        SceneManager.LoadScene("4-1");
        GameManager.Instance.nowStage = 10;
    }
}
