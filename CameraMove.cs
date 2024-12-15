using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 相机移动
/// </summary>
public class CameraMove : MonoBehaviour
{
    public Transform mainCamera;
    public List<List<Vector3>> allPointList = new List<List<Vector3>>();

    public List<Vector3> devicePoints = new List<Vector3>();
    public List<Vector3> tempPoints = new List<Vector3>();

    [SerializeField] private float index = 0;

    [SerializeField] private int subIndex = 0;
    [SerializeField] private int thridIndex = 0;

    public Transform pointPar;

    private bool isMoving = false;
    private float speed = 1f;


    public void UpdatePath(int index)
    {
        this.index = index;
        devicePoints = allPointList[index];
        thridIndex = 0;
        subIndex = 0;
        // isMoving = true;
    }
    private void MoveNextPoints()
    {
        if (subIndex > devicePoints.Count - 2)
        {
            isMoving = false;
            subIndex = 0;
        }
        float dis = 0;
        tempPoints.Clear();
        for (int i = subIndex; i < devicePoints.Count; i++)
        {
            if (devicePoints[i] == Vector3.zero)
            {
                subIndex = i + 1;
                break;

            }
            if (i + 1 < devicePoints.Count && devicePoints[i + 1] != Vector3.zero)
            {
                dis += Vector3.Distance(devicePoints[i], devicePoints[i + 1]);
            }
            if (i == devicePoints.Count - 1)
            {
                subIndex = i;
            }


            tempPoints.Add(devicePoints[i]);
        }
        speed = dis / 3f;
        thridIndex = 0;
    }



    void Start()
    {
        MoveNextPoints();
        var start = tempPoints[thridIndex];
        var end = tempPoints[thridIndex + 1];
        allTime = Vector3.Distance(start, end) / 1f;

    }
    void Update()
    {

        MoveCamera();
    }
    private float time = 0;
    private float allTime = 0;
    public void MoveCamera()
    {
        if (isMoving) return;
        if (thridIndex > tempPoints.Count - 2)
        {
            MoveNextPoints();
            thridIndex = 0;
        }
        var start = tempPoints[thridIndex];
        var end = tempPoints[thridIndex + 1];
        if (time > allTime)
        {
            thridIndex++;
            allTime = Vector3.Distance(start, end) / 1f;
            time = 0;

        }
        else
        {
            time += Time.deltaTime;

            int d = 1;
            var dir = end - start;
            float max = GetMax(dir.x, dir.y, dir.z);

            if (max == dir.x || max == -dir.x)
            {
                dir = Vector3.up;
                if (max == -dir.x)
                {
                    // d = -1;
                    dir = Vector3.left;
                }
            }
            else if (max == dir.y || max == -dir.y)
            {
                dir = Vector3.left;
                if (max == -dir.y)
                {
                    // d = -1;
                }
            }
            else if (max == dir.z || max == -dir.z)
            {
                dir = Vector3.up;
                if (max == -dir.z)
                {
                    d = -1;
                }
            }
            dir = dir.normalized;
            //计算两点的在竖直平面的法线

            //插值点





            //计算两点的在竖直平面的法线
            var normal = Vector3.Cross(end - start, dir).normalized;
            //插值点
            var point = Vector3.Lerp(start, end, time / allTime);
            //插值点在竖直平面的法线方向偏移
            var offset = point + normal * 5f * d;
            //插值点在竖直平面的法线方向偏移
            mainCamera.position = offset;
            mainCamera.LookAt(Vector3.Lerp(start, end, time / allTime));




        }


    }

    public float GetMax(float x, float y, float z)
    {
        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);

        return Mathf.Max(x, y, z);
    }

    public void DrawLine(List<Vector3> points)
    {
        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(points[i], points[i + 1], Color.red);

        }


    }

    private void OnDrawGizmos()
    {
        DrawLine(devicePoints);


    }
    [ContextMenu("Init")]
    public void Init()
    {
        devicePoints.Clear();
        for (int i = 0; i < pointPar.childCount; i++)
        {
            devicePoints.Add(pointPar.GetChild(i).position);

        }
    }

    [ContextMenu("StartMove")]
    public void StartMove()
    {

    }
}
