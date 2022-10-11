using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 point;
    private float speed;

    private void Start()
    {
        SetParam();
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if ((transform.position - point).magnitude <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void SetParam ()
    {
        direction = (InputParams.Instance.MovePosition - transform.position).normalized;
        direction.y = 0;
        point = InputParams.Instance.MovePosition;
        speed = InputParams.Instance.CurrentSpeed;
    }
}
