using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<GameObject> enemyList;
    private GameObject target;

    private void Awake()
    {
        enemyList = new List<GameObject>();
    }

    private void Update()
    {
        if (enemyList.Count < 1)
        {
            target = null;
            return;
        }
        else
        {
            target = enemyList[0];
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("added");
            enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("removed");
            enemyList.Remove(collision.gameObject);
        }
    }
}
