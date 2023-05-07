using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehavior : MonoBehaviour
{
    [SerializeField] 
    Transform followingTarget;
    [SerializeField, Range(0f,1f)] 
    float parallaxStrenght = 0.1f;
    [SerializeField]
    bool desableVerticalParalax;
    Vector3 targetPriviousPosition;
    void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPriviousPosition = followingTarget.position;
    }
    void Update()
    {
        var delta = followingTarget.position - targetPriviousPosition;

        if(desableVerticalParalax)
        {
            delta.y = 0f;
        }
        targetPriviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrenght;
    }
}
