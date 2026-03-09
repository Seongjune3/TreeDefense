using UnityEngine;
using System.Collections.Generic;

public class TutorialSummon : MonoBehaviour
{
    [System.Serializable]
    public class Talks
    {
        public GameObject talk;
    }

    public MenuManager menuManager;
    public TreeManager treeManager;

    public GameObject startTutorial;
    public GameObject talkOne_blindImages;
    public GameObject talkThree_blindImages;
    public GameObject lastTalk;

    [SerializeField]
    private List<Talks> talkList = new List<Talks>();

    private int currentIndex = 0;

    public bool isOpendCard = false;
    public bool cardOpend = false;
    public bool exitedSummon = false;
    public bool OnDeck = false;
    public bool openTreeInfo = false;
    public bool openEvoPanel = false;
    public bool closeEvoPanel = false;
    public bool addTree = false;
    public bool closeDeckPanel = false;


    void Start()
    {
        if (!GameManager.Instance.tutorialClear)
        {
            startTutorial.SetActive(true);
        }
    }

    void Update()
    {
        CheckPanelOpen();
        CheckCardOpend();
        CheckDeckPanelOn();
    }

    public void NextTalk()
    {
        if (GameManager.Instance.tutorialClear) return;
        
        if (currentIndex < talkList.Count)
        {
            // 현재 대화 끄기
            talkList[currentIndex].talk.SetActive(false);

            currentIndex++;

            // 다음 대화 켜기 }
            if (currentIndex < talkList.Count)
            {
                talkList[currentIndex].talk.SetActive(true);
            }
        }
    }

    public void TutorialSummonOne()
    {
        GameManager.Instance.treeCoin -= 1;
        treeManager.treeCoinText.text = "" + GameManager.Instance.treeCoin;
        treeManager.exitSummonButton.SetActive(false);
        SummonTutorialResult();
    }

    public void CheckPanelOpen()
    {
        if (menuManager.opendSummonPanel)
        {
            NextTalk();
            menuManager.opendSummonPanel = false;
            talkOne_blindImages.SetActive(false);
        }
    }

    public void SummonTutorialResult()
    {
        TreeManager.TreeData data = treeManager.treeList[0];

        treeManager.ownedTrees.Add(data.name);

        treeManager.resultPanel.SetActive(true);

        GameObject clone = Instantiate(data.prefab, treeManager.resultPanel.transform);
        clone.SetActive(true);
        data.treeImage.SetActive(false);

        treeManager.exitResultButton.SetActive(true);

        NextTalk();
    }

    public void TutorialEnd()
    {
        GameManager.Instance.tutorialClear = true;
        GameManager.Instance.treeCoin += 10;
        lastTalk.SetActive(false);
    }

    public void CheckCardOpend()
    {
        if (isOpendCard && !cardOpend)
        {
            NextTalk();
            cardOpend = true;
        }
        else if (cardOpend && exitedSummon)
        {
            exitedSummon = false;
            NextTalk();
        }
    }
    public void CheckDeckPanelOn()
    {
        if (OnDeck)
        {
            OnDeck = false;
            NextTalk();
        }
        if (openTreeInfo)
        {
            openTreeInfo = false;
            NextTalk();
        }
        if (openEvoPanel)
        {
            openEvoPanel = false;
            NextTalk();
        }
        if (closeEvoPanel)
        {
            closeEvoPanel = false;
            NextTalk();
        }
        if (addTree)
        {
            addTree = false;
            NextTalk();
        }
        if (closeDeckPanel)
        {
            closeDeckPanel = false;
            NextTalk();
        }
    }
}
