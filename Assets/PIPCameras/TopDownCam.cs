using UnityEngine;

public class TopDownCam : MonoBehaviour
{
    public float height = 15f;
    public float smoothSpeed = 5f;

    private Transform target;

    void LateUpdate()
    {
        ResolveTarget();

        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, height, target.position.z), smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    void ResolveTarget()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            GameObject dataObj = GameObject.FindWithTag("enemy");

            if (dataObj != null)
                target = dataObj.transform;
        }
    }
}