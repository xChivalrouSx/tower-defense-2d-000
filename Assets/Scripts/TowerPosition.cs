using UnityEngine;

public class TowerPosition : MonoBehaviour
{
    [SerializeField] private Transform towerPrefab;

    private bool isTowerPlaced;

    private void Awake()
    {
        isTowerPlaced = false;
    }

    void Update()
    {
        if (!isTowerPlaced && Input.GetMouseButtonDown(0))
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
