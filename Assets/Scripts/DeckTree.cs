using System;
using System.Collections;
using System.Collections.Generic;gi
using UnityEngine;

public class DeckTree : MonoBehaviour
{
    public GameObject equipButton;
    public GameObject removeButton;
    public GameObject evolutionButton;

    public GameObject onButtons;
    public GameObject offButtons;

    public GameObject evoPanel;
    public GameObject evoedPanel;

    public Star star;

    private bool equiped = false;
    private bool evolutioned = false;

    private TreeManager treeManager;
    private GameObject panelTowerList;
    private TutorialSummon tutorialSummon;

    private GameObject clone;

    [SerializeField]
    private string treeName;

    [SerializeField]
    private string feedName;

    public void Start()
    {
        treeManager = GameObject.FindGameObjectWithTag("TreeManager").GetComponent<TreeManager>();
        panelTowerList = GameObject.FindGameObjectWithTag("PanelTowerList");
        tutorialSummon = FindFirstObjectByType<TutorialSummon>();

        TreeManager.TreeData data = treeManager.treeList.Find(t => t.name == treeName);

        foreach (string treeName in GameManager.Instance.equipTrees)
        {
            if (data.name == treeName)
            {
                equiped = true;
            }
        }
    }

    public void equip()
    {
        if (!equiped)
        {
            TreeManager.TreeData data = treeManager.treeList.Find(t => t.name == treeName);

            foreach (string treeName in GameManager.Instance.equipTrees)
            {
                if (data.name == treeName)
                {
                    StartCoroutine(treeManager.errorTwoEquip());
                    removeButton.SetActive(true);
                    evolutionButton.SetActive(false);
                    return;
                }
            }

            clone = Instantiate(data.deck_TreeImage, panelTowerList.transform);

            GameManager.Instance.equipTrees.Add(treeName);

            equiped = true;

            removeButton.SetActive(true);
            evolutionButton.SetActive(false);
            tutorialSummon.addTree = true;
        }
    }

    public void remove()
    {
        if (equiped)
        {
            TreeManager.TreeData data = treeManager.treeList.Find(t => t.name == treeName);

            foreach (string treeName in GameManager.Instance.equipTrees)
            {
                if (data.name == treeName)
                {
                    treeManager.RemoveMyTrees(data.name);

                    Debug.Log(data.name);
                }
            }

            Destroy(clone);

            GameManager.Instance.equipTrees.Remove(treeName);

            equiped = false;

            removeButton.SetActive(false);
            evolutionButton.SetActive(true);
        }
    }

    public void OnEvolutionPanel()
    {
        if (evolutioned)
        {
            evoedPanel.SetActive(true);
            return;
        }
        evoPanel.SetActive(true);
        tutorialSummon.openEvoPanel = true;
    }

    public void OffEvolutionPanel()
    {
        if (evolutioned)
        {
            evoedPanel.SetActive(false);
            return;
        }
        evoPanel.SetActive(false);
        tutorialSummon.closeEvoPanel = true;
    }

    public void evolution()
    {
        if (!equiped && !evolutioned)
        {
            TreeManager.TreeData treeData = treeManager.treeList.Find(t => t.name == treeName);

            int treeCount = treeData.count;

            string feedItem = GameManager.Instance.itemList.Find(t => t == feedName);

            if (treeCount >= 5 && feedItem != null)
            {
                if (treeName == "IceTree")
                {
                    for (int i = 0; i < treeData.treeSetting.weapon.Length; i++)
                    {
                        treeData.treeSetting.weapon[i].slow += 0.2f;
                        treeData.treeSetting.weapon[i].range += 1;
                    }
                    evolutioned = true;
                    star.starImage.SetActive(true);
                    evoPanel.SetActive(false);
                    treeData.evolutioned = true;
                }
                else if (treeName == "BuffTree")
                {
                    for (int i = 0; i < treeData.treeSetting.weapon.Length; i++)
                    {
                        treeData.treeSetting.weapon[i].buff += 0.2f;
                        treeData.treeSetting.weapon[i].range += 1;
                    }
                    evolutioned = true;
                    star.starImage.SetActive(true);
                    evoPanel.SetActive(false);
                    treeData.evolutioned = true;
                }
                else if (treeName == "GoldTree")
                {
                    for (int i = 0; i < treeData.treeSetting.weapon.Length; i++)
                    {
                        treeData.treeSetting.weapon[i].money += 300;
                        treeData.treeSetting.weapon[i].range += 1;
                    }
                    evolutioned = true;
                    star.starImage.SetActive(true);
                    evoPanel.SetActive(false);
                    treeData.evolutioned = true;
                }
                else
                {
                    for (int i = 0; i < treeData.treeSetting.weapon.Length; i++)
                    {
                        treeData.treeSetting.weapon[i].damage += 5;
                        treeData.treeSetting.weapon[i].range += 1;
                    }
                    evolutioned = true;
                    star.starImage.SetActive(true);
                    evoPanel.SetActive(false);
                    treeData.evolutioned = true;
                }
            }
        }
    }

    public void OnButtons()
    {
        if (equiped)
        {
            onButtons.SetActive(false);

            equipButton.SetActive(true);
            removeButton.SetActive(true);

            offButtons.SetActive(true);

            return;
        }
        onButtons.SetActive(false);

        equipButton.SetActive(true);
        evolutionButton.SetActive(true);

        offButtons.SetActive(true);

        tutorialSummon.openTreeInfo = true;
    }

    public void OffButtons()
    {
        offButtons.SetActive(false);

        equipButton.SetActive(false);
        removeButton.SetActive(false);
        evolutionButton.SetActive(false);

        onButtons.SetActive(true);
    }
}
