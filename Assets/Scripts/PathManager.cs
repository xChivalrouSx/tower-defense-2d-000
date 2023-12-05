using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static List<Transform> PathPoints { get; set; }

    private void Awake()
    {
        PathPoints = new List<Transform>(); ;
        for (int i = 0; i < transform.childCount; i++)
        {
            PathPoints.Add(transform.GetChild(i));
        }
    }
}
