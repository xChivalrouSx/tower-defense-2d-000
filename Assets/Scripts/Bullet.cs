using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 3f;

    private Transform target;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rigidBody.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == target)
        {
            Destroy(gameObject);
            target.GetComponent<Enemy>().DestroySelf();
        }

    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}
