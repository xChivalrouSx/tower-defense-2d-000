using System.Collections;
using TMPro;
using UnityEngine;

public class WaweManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private TextMeshProUGUI countDownText;

    private Transform spawnPoint;

    private readonly float maxTimeBetweenWaves = 5f;
    private float countdownBetweenWaves;

    private int waveIndex = 0;
    private int numberOfEnemy = 0;

    private void Start()
    {
        spawnPoint = PathManager.PathPoints[0];
        countdownBetweenWaves = maxTimeBetweenWaves;
        countDownText.text = countdownBetweenWaves.ToString("##");
    }

    private void Update()
    {
        if (countdownBetweenWaves <= 0f)
        {
            StartCoroutine(SpawnWawe());
            countdownBetweenWaves = maxTimeBetweenWaves;
        }
        countdownBetweenWaves -= Time.deltaTime;

        countDownText.text = countdownBetweenWaves.ToString("##");
    }

    private IEnumerator SpawnWawe()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);

        }
    }

    private void SpawnEnemy()
    {
        Transform newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        newEnemy.name = (++numberOfEnemy).ToString();
    }

}
