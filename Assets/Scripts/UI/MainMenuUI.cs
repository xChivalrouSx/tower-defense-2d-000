using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        newGameButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.TestLevel);
        });
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
