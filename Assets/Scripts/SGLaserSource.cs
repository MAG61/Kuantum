using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGLaserSource : MonoBehaviour
{
    [SerializeField] public float defDistanceRay = 100;
    public Transform laserPoint;
    public LineRenderer lineRenderer;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(laserPoint.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserPoint.position, transform.right);
            Draw2DRay(laserPoint.position, hit.point);
            if (hit.transform.tag == "Source")
            {
                hit.transform.GetComponent<SGSource>().ShootLaser('z', 0);
            }
        }
        else
        {
            Draw2DRay(laserPoint.position, laserPoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
