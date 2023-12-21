using UnityEngine;

public class TowerPosition : MonoBehaviour
{
    [SerializeField] private Transform towerPrefab;
    [SerializeField] private GameObject selectableUI;

    private bool isTowerPlaced;

    private void Awake()
    {
        isTowerPlaced = false;
    }

    private void Start()
    {
        BudgetManager.Instance.OnTowerAddCliecked += BudgetManager_OnTowerAddCliecked;
    }

    private void BudgetManager_OnTowerAddCliecked(object sender, System.EventArgs e)
    {
        bool isActive = !isTowerPlaced && BudgetManager.Instance.CanAddTower;
        selectableUI.SetActive(isActive);
    }

    void Update()
    {
        if (selectableUI.activeSelf && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
            foreach (var hit in hits)
            {
                if (hit.collider.name == name)
                {
                    Transform newTower = Instantiate(towerPrefab);
                    newTower.position = hit.collider.transform.position;
                    isTowerPlaced = newTower.GetComponent<Tower>().IsPlaced;
                }
            }
        }
    }
}
