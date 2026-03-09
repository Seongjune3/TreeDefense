using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    [System.Serializable] //이거 해야지 인스펙터에서 보임
    public class TreeData
    {
        public string name;
        public string evoFeedName;
        public GameObject prefab;
        public TowerTemplate treeSetting;
        public int count; // 중복 개수
        public GameObject treeImage;
        public GameObject deck_Tree;
        public GameObject deck_TreeImage;
        public bool evolutioned;
    }
    public GameObject resultPanel;
    public GameObject exitResultButton;
    public GameObject exitSummonButton;

    private bool summonOneTree;
    private bool summonTenTree;

    public int opendCard;

    public TextMeshProUGUI treeCoinText;

    public List<TreeData> treeList = new List<TreeData>();

    public HashSet<string> ownedTrees = new HashSet<string>(); //중복 자동으로 막아줌

    public List<string> cloneTrees = new List<string>();

    [SerializeField]
    private List<string> summonTrees = new List<string>();

    private GameObject panelTowerList;

    public GameObject errorText;


    private void Awake()
    {
        treeCoinText.text = "" + GameManager.Instance.treeCoin;
    }

    public void Start()
    {
        panelTowerList = GameObject.FindGameObjectWithTag("PanelTowerList");
        myTrees();
    }

    public void Update()
    {
        Result();
        OnExitButton();
        if (GameManager.Instance.tutorialClear)
        {
            CoinText();
        }
    }

    public void SummonOne()
    {
        if (GameManager.Instance.treeCoin >= 1)
        {
            exitSummonButton.SetActive(false);
            GameManager.Instance.treeCoin -= 1;
            treeCoinText.text = "" + GameManager.Instance.treeCoin;
            SummonTree(Random.Range(0, treeList.Count));
            summonOneTree = true;
        }
    }

    public void SummonTen()
    {
        if (GameManager.Instance.treeCoin >= 10)
        {
            exitSummonButton.SetActive(false);
            GameManager.Instance.treeCoin -= 10;
            treeCoinText.text = "" + GameManager.Instance.treeCoin;
            for (int i = 0; i < 10; i++)
            {
                SummonTree(Random.Range(0, treeList.Count));
            }
            summonTenTree = true;
        }
    }

    private void SummonTree(int result)
    {
        var tree = treeList[result];

        if (!ownedTrees.Contains(tree.name))
        {
            ownedTrees.Add(tree.name);
            summonTrees.Add(tree.name);
            GameManager.Instance.haveTrees.Add(tree.name);
        }
        else
        {
            summonTrees.Add(tree.name);
            tree.count++;
        }
    }

    private void ShowResult()
    {
        resultPanel.SetActive(true);

        // 리스트안에있는 문자열을 하나하나씩 검사
        foreach (string treeName in summonTrees)
        {
            TreeData data = treeList.Find(t => t.name == treeName);
            if (data != null && data.prefab != null)
            {
                GameObject clone = Instantiate(data.prefab, resultPanel.transform);
                clone.SetActive(true);
                data.treeImage.SetActive(false);
            }
        }

        summonTrees.Clear();
    }

    public void Result()
    {
        if (summonOneTree || summonTenTree)
        {
            ShowResult();
        }
    }

    public void OnExitButton()
    {
        if (opendCard == 1 && summonOneTree)
        {
            exitResultButton.SetActive(true);

        }
        else if (opendCard == 10 && summonTenTree)
        {
            exitResultButton.SetActive(true);
        }
    }

    public void ExitResult()
    {
        resultPanel.SetActive(false);
        summonOneTree = false;
        summonTenTree = false;
        exitResultButton.SetActive(false);
        exitSummonButton.SetActive(true);

        opendCard = 0;

        Transform[] childList = resultPanel.GetComponentsInChildren<Transform>();

        for (int i = 1; i < childList.Length; i++)
        {
            if (childList[i] != transform)
            {
                Destroy(childList[i].gameObject);
            }
        }
    }

    public void CoinText()
    {
        treeCoinText.text = "" + GameManager.Instance.treeCoin;
    }

    public void myTrees()
    {
        foreach (string treeName in GameManager.Instance.equipTrees)
        {
            TreeData data = treeList.Find(t => t.name == treeName);
            
            GameObject clone = Instantiate(data.deck_TreeImage , panelTowerList.transform);

            clone.name = data.name;

            cloneTrees.Add(data.name);
        }
        
    }

    public void RemoveMyTrees(string name)
    {
        foreach (Transform child in panelTowerList.transform)
        {
            foreach (string cloneName in cloneTrees)
            {
                if (child.name == cloneName && cloneName == name)
                {
                    Destroy(child.gameObject);
                    break;
                }
            }
        }
    }

    public IEnumerator errorTwoEquip()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(1f);
        errorText.SetActive(false);
    }
}