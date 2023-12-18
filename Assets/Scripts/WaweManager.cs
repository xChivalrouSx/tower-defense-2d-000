using System.Collections;
using TMPro;
using UnityEngine;

public class WaweManager : MonoBehaviour
{
    private enum WaweState
    {
        WaitForNewWawe,
        WaweStart
    }

    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private TextMeshProUGUI countDownText;

    private Transform spawnPoint;

    private readonly float waitTimePerEnemy = 5f;
    private float countdownBetweenWaves;

    private int waveIndex = 1;
    private int numberOfEnemy = 0;

    private WaweState currentState;

    private void Start()
    {
        currentState = WaweState.WaitForNewWawe;

        countdownBetweenWaves = waitTimePerEnemy * waveIndex;
        countDownText.text = countdownBetweenWaves.ToString("##");

        spawnPoint = PathManager.PathPoints[0];
    }

    private void Update()
    {
        switch (currentState)
        {
            case WaweState.WaitForNewWawe:
                if (countdownBetweenWaves <= 0f)
                {
                    countDownText.text = string.Empty;
                    currentState = WaweState.WaweStart;
                }
                countdownBetweenWaves -= Time.deltaTime;
                countDownText.text = countdownBetweenWaves.ToString("##");
                return;
            case WaweState.WaweStart:
                StartCoroutine(SpawnWawe());
                countdownBetweenWaves = waitTimePerEnemy * waveIndex;
                currentState = WaweState.WaitForNewWawe;
                return;
        }
    }

    private IEnumerator SpawnWawe()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);

        }
        waveIndex++;
    }

    private void SpawnEnemy()
    {
        Transform newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        newEnemy.name = (++numberOfEnemy).ToString();
    }

}
