using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Talk : MonoBehaviour
{
    [System.Serializable]
    public class Talks
    {
        public GameObject talk;
    }

    public GameObject tutorial;

    public GameObject blindImage;
    public GameObject blindImages;
    public GameObject treeInfoImage;

    public GameObject wrongPanel;
    public GameObject truePanel;

    public TowerSpawner towerSpawner;
    public WaveSystem waveSystem;
    public EnemySpawner enemySpawner;
    public TowerDataViewer towerDataViewer;

    public bool plantChecked = false;

    [SerializeField]
    private List<Talks> talkList = new List<Talks>();

    private int currentIndex = 0;

    public void Start()
    {
        blindImage.SetActive(true);
    }

    public void Update()
    {
        CheckPlant();
        CheckStart();
        CheckUpgrade();
    }


    public void NextTalk()
    {
        if (currentIndex < talkList.Count)
        {
            // 현재 대화 끄기
            talkList[currentIndex].talk.SetActive(false);
            currentIndex++;


            // 다음 대화 켜기 }
            if (currentIndex < talkList.Count)
            {
                talkList[currentIndex].talk.SetActive(true);
                if (currentIndex == 5)
                {
                    blindImage.SetActive(false);
                }
            }
        }
    }

    public void CheckPlant()
    {
        if (towerSpawner.tutorialTowerPlant && !plantChecked)
        {
            treeInfoImage.SetActive(false);
            NextTalk();
            towerSpawner.tutorialTowerPlant = false;
            plantChecked = true;
            blindImage.SetActive(true);
        }
    }

    public void CheckStart()
    {
        if (waveSystem.tutorialStartWave && enemySpawner.CurrentEnemyCount <= 0)
        {
            NextTalk();
            waveSystem.tutorialStartWave = false;
        }
        else if (waveSystem.tutorialStartWave)
        {
            talkList[currentIndex].talk.SetActive(false);
        }
    }

    public void CheckUpgrade()
    {
        if (towerDataViewer.tutorialTowerUpgrade)
        {
            towerDataViewer.tutorialTowerUpgrade = false;
            talkList[currentIndex].talk.SetActive(false);
            NextTalk();
        }
    }

    public void WrongChoose()
    {
        talkList[currentIndex].talk.SetActive(false);
        wrongPanel.SetActive(true);
        GameManager.Instance.treeCoin += 1;
        StartCoroutine(WaitNextScene());
    }

    public void TrueChoose()
    {
        talkList[currentIndex].talk.SetActive(false);
        truePanel.SetActive(true);
        GameManager.Instance.treeCoin += 3;
        StartCoroutine(WaitNextScene());
    }

    public IEnumerator WaitNextScene()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu");

    }
}