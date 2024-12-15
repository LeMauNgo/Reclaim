using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCtrl : MyBehaviour
{
    [SerializeField] List<Transform> points;
    public List<Transform> Points => points;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoints();
    }
    void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform t in transform)
        { 
            points.Add(t);
        }
        Debug.Log("LoadPoints", gameObject);
    }
    public Vector3 GetPoint(int index)
    {
        return points[index].position;
    }
}
