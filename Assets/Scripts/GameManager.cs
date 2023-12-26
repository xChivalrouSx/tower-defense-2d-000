using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameOverUI;

    public static GameManager Instance { get; private set; }

    private int life = 5;


    private void Awake()
    {
        Instance = this;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;

        lifeText.text = life.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void GetDemage()
    {
        life -= 1;
        lifeText.text = life.ToString();

        if (life <= 0)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }

}
