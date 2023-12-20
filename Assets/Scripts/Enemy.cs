using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public float Earning { get; private set; }

    private readonly float speed = 2f;
    private float totalHealth = 100f;
    private float health;

    private Transform target;
    private int wavePathIndex = 0;

    private void Start()
    {
        health = totalHealth;
        UpdateHealthBar();

        target = PathManager.PathPoints[wavePathIndex];

        Earning = 50f;
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= .1f)
        {
            GetNextPathPoint();
        }
    }

    private void GetNextPathPoint()
    {
        if (wavePathIndex >= PathManager.PathPoints.Count - 1)
        {
            Destroy(gameObject);
            return;
        }

        target = PathManager.PathPoints[++wavePathIndex];
    }

    public void TakeDamage(float demage)
    {
        health = Mathf.Max(0, health - demage);
        UpdateHealthBar();
        if (health <= 0)
        {
            DestroySelf();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health / totalHealth;
    }

    private void DestroySelf()
    {
        BudgetManager.Instance.AddMoney(Earning);
        Destroy(gameObject);
    }
}
