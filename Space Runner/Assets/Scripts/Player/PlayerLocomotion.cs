using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, position, 0.1f);
        }
    }
}
