using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetControl : MonoBehaviour
{
    static void StraightenArm()
    {
        GameObject arm = GameObject.FindGameObjectsWithTag("arm")[0];
        arm.GetComponent<HandTracking>().Straighten();
    }

    void Start() { }

    void Update() { }
}
