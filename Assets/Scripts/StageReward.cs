using UnityEngine;
using UnityEngine.SceneManagement;

public class StageReward : MonoBehaviour
{
    public int getTreeCoin;
    void OnEnable()
    {
        GameManager.Instance.treeCoin += getTreeCoin;
        switch (GameManager.Instance.nowStage)
        {
            case 1:
                GameManager.Instance.itemList.Add("Leaf");
                break;
            case 2:
                GameManager.Instance.itemList.Add("ThunderOrb");
                break;
            case 3:
                GameManager.Instance.itemList.Add("IceOrb");
                break;
            case 4:
                GameManager.Instance.itemList.Add("Cross");
                break;
            case 5:
                GameManager.Instance.itemList.Add("FireOrb");
                break;
            case 6:
                GameManager.Instance.itemList.Add("WaterOrb");
                break;
            case 7:
                GameManager.Instance.itemList.Add("StoneOrb");
                break;
            case 8:
                GameManager.Instance.itemList.Add("WindOrb");
                break;
            case 9:
                GameManager.Instance.itemList.Add("GoldOrb");
                break;
            case 10:
                GameManager.Instance.itemList.Add("PoisonOrb");
                break;
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.nowStage = 0;
    }
}
