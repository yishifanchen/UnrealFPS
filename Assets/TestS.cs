using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestS : MonoBehaviour {
    public Vector3 desiredMove;
	// Use this for initialization
	void Start () {
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hitInfo,
            0.5f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
        print("hitInfo.normal"+hitInfo.normal);
        print(desiredMove);
    }
}
