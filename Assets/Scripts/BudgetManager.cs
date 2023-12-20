using TMPro;
using UnityEngine;

public class BudgetManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public static BudgetManager Instance { get; private set; }

    private float money;

    private void Awake()
    {
        Instance = this;

        money = 200f;
    }

    public float GetMoney()
    {
        return money;
    }

    public void AddMoney(float addMoney)
    {
        money += addMoney;
        moneyText.text = "Money: " + money;
    }

    public void SpendMoney(float spendAmount)
    {
        if (money >= spendAmount)
        {
            money -= spendAmount;
            moneyText.text = "Money: " + money;
        }

    }

}
