using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaddleRectangleFollower : MonoBehaviour
{
    private PaddleRectangle rectangleFollower;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [SerializeField]
    private float _sensitivity = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 destination = rectangleFollower.transform.position;

        //_rigidbody.transform.rotation = transform.rotation;
        _rigidbody.transform.DORotate(transform.rotation.eulerAngles, 1 / _sensitivity);

        _velocity = (destination - _rigidbody.transform.position) * _sensitivity;

        _rigidbody.velocity = _velocity;

        //transform.rotation = rectangleFollower.transform.rotation;

        transform.transform.DORotate(rectangleFollower.transform.rotation.eulerAngles, 1 / _sensitivity); 
    }

    public void SetFollowTarget(PaddleRectangle batFollower)
    {
        rectangleFollower = batFollower;
    }
}
