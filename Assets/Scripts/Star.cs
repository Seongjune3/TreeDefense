using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject starImage;

    private TreeManager treeManager;

    [SerializeField]
    private string treeName;

    public void OnEnable()
    {
        if (treeManager == null)
            treeManager = GameObject.FindGameObjectWithTag("TreeManager").GetComponent<TreeManager>();

        TreeManager.TreeData treeData = treeManager.treeList.Find(t => t.name == treeName);

        if (treeData.evolutioned)
        {
            starImage.SetActive(true);
        }
    }
}
