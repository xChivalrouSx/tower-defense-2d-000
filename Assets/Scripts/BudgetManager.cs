using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BudgetManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button addTowerButton;
    [SerializeField] private Image addTowerDisableUI;

    public event EventHandler OnTowerAddCliecked;

    public static BudgetManager Instance { get; private set; }

    public bool CanAddTower { get; private set; }

    private float money;
    private readonly float towerPrice = 200f;

    private void Awake()
    {
        Instance = this;

        money = towerPrice;
        CanAddTower = false;

        addTowerButton.onClick.AddListener(() =>
        {
            CanAddTower = !CanAddTower;
            OnTowerAddCliecked?.Invoke(this, EventArgs.Empty);
        });
    }

    public float GetMoney()
    {
        return money;
    }

    public void AddMoney(float addMoney)
    {
        money += addMoney;
        SetUIAfterChangeMoney();
    }

    public void SpendMoney(float spendAmount)
    {
        if (money >= spendAmount)
        {
            money -= spendAmount;
            SetUIAfterChangeMoney();
            if (towerPrice > money)
            {
                CanAddTower = false;
                OnTowerAddCliecked?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void SetUIAfterChangeMoney()
    {
        moneyText.text = "Money: " + money;
        addTowerButton.enabled = towerPrice <= money;
        addTowerDisableUI.gameObject.SetActive(!addTowerButton.enabled);
    }

}
