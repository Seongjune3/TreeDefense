using UnityEngine;

public class ChapterClear : MonoBehaviour
{
    private WaveSystem waveSystem;
    private EnemySpawner enemySpawner;

    public GameObject clearPanel;

    private bool clearThisStage = false;

    public bool isFaild = false;



    void Start()
    {
        waveSystem = FindAnyObjectByType<WaveSystem>();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }

    void Update()
    {
        StageClear();
    }

    public void StageClear()
    {
        if (waveSystem.MaxWave == waveSystem.CurrentWave && enemySpawner.EnemyList.Count == 0 && !clearThisStage && !isFaild)
        {
            int index = GameManager.Instance.nowStage - 1; // nowStage가 1부터 시작하므로 인덱스는 -1

            // index가 음수가 아니고 배열 길이 안 넘어가게
            if (index >= 0 && index < GameManager.Instance.clearStages.Length)
            {
                GameManager.Instance.clearStages[index] = true;
                clearPanel.SetActive(true);
                clearThisStage = true;
            }
        }
    }
}