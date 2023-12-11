using System;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    class CustomTransformComparerWithIntName : IComparer<Transform>
    {
        public int Compare(Transform x, Transform y)
        {
            int xIntValue = Int32.Parse(x.name);
            int yIntValue = Int32.Parse(y.name);
            return xIntValue.CompareTo(yIntValue);
        }
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform rotationPart;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletPerSecond = 1f;

    private Transform target;
    private float timeUntilFire;
    private List<Transform> enemyList;

    private void Awake()
    {
        enemyList = new List<Transform>();
    }

    private void Update()
    {
        if (enemyList.Count < 1)
        {
            target = null;
            return;
        }

        target = enemyList[0];
        float angle = Mathf.Atan2(target.position.y - rotationPart.position.y, target.position.x - rotationPart.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180));
        rotationPart.rotation = Quaternion.RotateTowards(rotationPart.rotation, targetRotation, 300f * Time.deltaTime);

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / bulletPerSecond)
        {
            Fire();
            timeUntilFire = 0f;
        }

    }

    private void Fire()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetTarget(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemyList.Add(collision.transform);
            enemyList.Sort(new CustomTransformComparerWithIntName());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemyList.Remove(collision.transform);
        }
    }
}
