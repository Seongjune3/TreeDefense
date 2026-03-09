using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPanel;
    [SerializeField]
    private GameObject summonPanel;
    [SerializeField]
    private GameObject mapPanel;
    [SerializeField]
    private GameObject trees;
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject summon;
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject deckPanel;
    [SerializeField]
    private GameObject deck;
    [SerializeField]
    private GameObject treeDeck;
    [SerializeField]
    private GameObject treeList;

    [SerializeField]
    private List<string> onTrees = new List<string>();

    private TreeManager treeManager;
    private TutorialSummon tutorialSummon;

    public bool opendSummonPanel = false;

    public void Start()
    {
        treeManager = GameObject.FindGameObjectWithTag("TreeManager").GetComponent<TreeManager>();
        tutorialSummon = FindFirstObjectByType<TutorialSummon>();
    }

    public void OnItemPanel()
    {
        itemPanel.SetActive(false);
        summonPanel.SetActive(false);
        mapPanel.SetActive(false);
        trees.SetActive(false);
        deckPanel.SetActive(false);

        inventory.SetActive(true);
    }

    public void OnSummonPanel()
    {
        itemPanel.SetActive(false);
        summonPanel.SetActive(false);
        mapPanel.SetActive(false);
        trees.SetActive(false);
        deckPanel.SetActive(false);

        summon.SetActive(true);

        opendSummonPanel = true;
    }

    public void OnMapPanel()
    {
        itemPanel.SetActive(false);
        summonPanel.SetActive(false);
        mapPanel.SetActive(false);
        trees.SetActive(false);
        deckPanel.SetActive(false);

        map.SetActive(true);
    }

    public void OffSummonPanel()
    {
        itemPanel.SetActive(true);
        summonPanel.SetActive(true);
        mapPanel.SetActive(true);
        trees.SetActive(true);
        deckPanel.SetActive(true);
        tutorialSummon.exitedSummon = true;

        summon.SetActive(false);
    }

    public void OffItemPanel()
    {
        itemPanel.SetActive(true);
        summonPanel.SetActive(true);
        mapPanel.SetActive(true);
        trees.SetActive(true);
        deckPanel.SetActive(true);

        inventory.SetActive(false);
    }

    public void OffDeckPaenl()
    {
        itemPanel.SetActive(true);
        summonPanel.SetActive(true);
        mapPanel.SetActive(true);
        trees.SetActive(true);
        deckPanel.SetActive(true);
        tutorialSummon.closeDeckPanel = true;

        deck.SetActive(false);
        treeDeck.SetActive(false);
    }

    public void OffMapPaenl()
    {
        itemPanel.SetActive(true);
        summonPanel.SetActive(true);
        mapPanel.SetActive(true);
        trees.SetActive(true);
        deckPanel.SetActive(true);

        map.SetActive(false);
    }

    public void OnDeckPanel()
    {
        itemPanel.SetActive(false);
        summonPanel.SetActive(false);
        mapPanel.SetActive(false);
        trees.SetActive(false);
        deckPanel.SetActive(false);

        deck.SetActive(true);
        treeDeck.SetActive(true);
        tutorialSummon.OnDeck = true;

        treeManager.ownedTrees = new HashSet<string>(GameManager.Instance.haveTrees);

        foreach (string treeName in treeManager.ownedTrees)
        {
            TreeManager.TreeData data = treeManager.treeList.Find(t => t.name == treeName);
            if (data != null && data.deck_Tree != null)
            {
                if (onTrees.Contains(data.deck_Tree.name))
                {
                    continue;
                }
                GameObject clone = Instantiate(data.deck_Tree, treeList.transform);
                clone.SetActive(true);
                onTrees.Add(data.deck_Tree.name);
            }
        }
    }
}