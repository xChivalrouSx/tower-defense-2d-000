using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private GameObject gameOverUI;

    public static GameManager Instance { get; private set; }

    private int life = 5;


    private void Awake()
    {
        Instance = this;
        gameOverUI.SetActive(false);

        lifeText.text = life.ToString();
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
