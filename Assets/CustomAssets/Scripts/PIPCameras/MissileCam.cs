using UnityEngine;

public class MissileCam : MonoBehaviour
{
    public Transform missile;

    public float distance = 10f;
    public float height = 4f;
    public float smoothSpeed = 5f;

    private Transform target;

    void LateUpdate()
    {
        if (missile == null)
            return;

        ResolveTarget();

        if (target == null)
            return;

        Vector3 dir = (target.position - missile.position).normalized;

        Vector3 desiredPosition =
            missile.position
            - dir * distance
            + Vector3.up * height;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        Vector3 lookPoint = (missile.position + target.position) * 0.5f;

        transform.LookAt(lookPoint);
    }

    void ResolveTarget()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            GameObject dataObj = GameObject.FindWithTag("data");

            if (dataObj != null)
                target = dataObj.transform;
        }
    }
}