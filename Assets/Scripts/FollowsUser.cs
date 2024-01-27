using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowsUser : MonoBehaviour
{
    [SerializeField] Transform headAnchor;
    [SerializeField] Transform cubeAnchor;
    [SerializeField] bool applyOffset = true;

    float followGain = 0.1f;
    void Update()
    {
        var userPosOnFloor = new Vector3(headAnchor.position.x, 0, headAnchor.position.z);
        var userForwardOnFloor = new Vector3(headAnchor.forward.x, 0, headAnchor.forward.z);
        var offset = Offset(new Vector2(userPosOnFloor.x - cubeAnchor.position.x, userPosOnFloor.z - cubeAnchor.position.z));
        transform.position = Vector3.Lerp(transform.position, userPosOnFloor, followGain) + (applyOffset ? new Vector3(offset.x, 0, offset.y) : Vector3.zero);
        transform.forward = Vector3.Slerp(transform.forward, userForwardOnFloor, followGain);
    }

    float radius = 2;
    float steepness = 2f;
    Vector2 Offset(Vector2 position)
    {
        var d = Mathf.Pow(position.x, 2) + Mathf.Pow(position.y, 2);
        var x = Mathf.Sign(position.x) * Sigmoid((-d + radius) * steepness);
        return new Vector2(x / 30f, 0);
    }

    float Sigmoid(float x)
    {
        return 1 / (1 + Mathf.Exp(-x));
    }
}
