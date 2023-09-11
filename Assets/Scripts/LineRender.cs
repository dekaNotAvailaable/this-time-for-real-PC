//using UnityEngine;

//public class RaycastTrail : MonoBehaviour
//{
//    public LineRenderer lineRenderer;
//    public Transform startPoint;
//    private RaycastHit hitInfo;
//    void Start()
//    {
//        lineRenderer = GetComponent<LineRenderer>();
//    }
//    void Update()
//    {
//        if (Physics.Raycast(startPoint.position, startPoint.forward, out hitInfo, Mathf.Infinity))
//        {

//            lineRenderer.SetPosition(0, startPoint.position);
//            lineRenderer.SetPosition(1, hitInfo.point);
//        }
//    }
//}