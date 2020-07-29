using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPosition : MonoBehaviour
{
    private Vector3 positionToLookAt;

    private void Start()
    {
        positionToLookAt = transform.position;
    }

    private void Update()
    {
        Vector3 aimDirection = (positionToLookAt - transform.position).normalized;
        float angleInDeg = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleInDeg);
    }

    public void SetPositionToLookAt(Vector3 positionToLookAt)
    {
        this.positionToLookAt = positionToLookAt;
    }
}
