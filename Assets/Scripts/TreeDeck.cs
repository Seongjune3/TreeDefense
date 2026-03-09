using System.Collections.Generic;
using UnityEngine;

public class TreeDeck : MonoBehaviour
{
    [System.Serializable]
    public class Trees
    {
        public string treeName;
        public GameObject treeUI;
    }

    private List<string> equipTree;

    public List<Trees> trees = new List<Trees>();
    

    public void Start()
    {
        equipTree = GameManager.Instance.equipTrees;
        equipTreesInDeck();
    }
    
    public void equipTreesInDeck()
    {
        foreach (string treeNames in equipTree)
        {
            Trees data = trees.Find(t => t.treeName == treeNames);

            data.treeUI.SetActive(true);
        }
    }
}
