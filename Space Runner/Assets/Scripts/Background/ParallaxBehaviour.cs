using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private float _positionToRepeat = -8;
    [SerializeField] private float _parallaxStrength;
    [SerializeField] private float _parallaxSpeed;
    void Update()
    {
        transform.position += new Vector3(0, -2 * Time.deltaTime * _parallaxStrength * _parallaxSpeed, 0);

        if(transform.position.y < _positionToRepeat)
        {
            transform.position = new Vector3(transform.position.x, -_positionToRepeat, transform.position.z);
        }
    }
}
