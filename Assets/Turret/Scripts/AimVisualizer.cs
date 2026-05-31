using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AimVisualizer : MonoBehaviour
{
    [SerializeField] 
    private Transform firePoint;
    [SerializeField] 
    private float maxDistance = 50f; //adjust n test 
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateAimLine();
    }




    private void UpdateAimLine()
    {
        Vector3 start = firePoint.position;

        Vector3 end =  start + firePoint.forward * maxDistance;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}

//add raycast to detect enemy and change line color later 