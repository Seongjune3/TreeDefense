using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int treeCoin;

    public bool tutorialClear = false;

    public bool[] clearStages = new bool[10];

    public int nowStage = 0;

    public List<string> equipTrees;

    public List<string> haveTrees;

    public List<string> itemList;

    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}