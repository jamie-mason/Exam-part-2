using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;
    [SerializeField] float camDistance;
    BallController ball = new BallController();
    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.isFalling()) {
            Quaternion rotation = cameraTransform.rotation;
            Vector3 position = target.position - (rotation * Vector3.forward * camDistance);

            cameraTransform.position = position;
            cameraTransform.rotation = rotation;
        }

    }
}
