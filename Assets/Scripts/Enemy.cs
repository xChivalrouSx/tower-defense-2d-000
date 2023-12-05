using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5f;

    private Transform target;
    private int wavePathIndex = 0;

    private void Start()
    {
        target = PathManager.PathPoints[wavePathIndex];
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
}
