using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRectangle : MonoBehaviour
{
    [SerializeField]
    private PaddleRectangleFollower paddleRectangleFollower;

    private void SpawnPaddleRectangleFollower()
    {
        var follower = Instantiate(paddleRectangleFollower);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnPaddleRectangleFollower();
    }
}
