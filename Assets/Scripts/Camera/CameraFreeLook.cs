using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeLook : MonoBehaviour
{
    /*PARAMS*/
    [Header("Distance")]
    public float minDistance = 1.5f;
    public float maxDistance = 6f;

    [Header("Scroll")]
    public float minScroll = 2.5f;
    public float maxScroll = 6f;
    public float scrollIntesivity = 0.2f;

    [Space]
    public float smooth = 150f;
    //public Vector3 cameraDirectionAdjusted;
   
    static float x;
    static float y;
    static float z;
    private Vector3 _cameraDir;
    private float _distance;


    /*PRIVATE METHODS*/
    void Awake()
    {
        _cameraDir = transform.localPosition.normalized;
        _distance = transform.localPosition.magnitude;
        
        x = Mathf.Tan(Camera.main.fieldOfView / 2) * Camera.main.nearClipPlane;
        y = x / Camera.main.aspect;
        z = Camera.main.nearClipPlane;
    }

    void Update()
    {
        RayCastAnalysis();
    }

    void RayCastAnalysis()
    {
        Vector3 desireCameraPos = transform.parent.TransformPoint(_cameraDir * maxDistance);
        RaycastHit hit;

        _distance = maxDistance;

        if (Physics.Linecast(transform.parent.position, desireCameraPos + new Vector3(x, y, z), out hit))
        {
            if (_distance > Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance))
                _distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }
        if (Physics.Linecast(transform.parent.position, desireCameraPos + new Vector3(x, -y, z), out hit))
        {
            if (_distance > Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance))
                _distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }
        if (Physics.Linecast(transform.parent.position, desireCameraPos + new Vector3(-x, y, z), out hit))
        {
            if (_distance > Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance))
                _distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }
        if (Physics.Linecast(transform.parent.position, desireCameraPos + new Vector3(-x, -y, z), out hit))
        {
            if (_distance > Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance))
                _distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, _cameraDir * _distance, Time.deltaTime * smooth);
    }


    /*PUBLIC METHODS*/
    public void Scrolling(float mouseScroll)
    {
        maxDistance += mouseScroll * scrollIntesivity;
        maxDistance = Mathf.Clamp(maxDistance, minScroll, maxScroll);
    }

    public void SetDistance(float distance)
    {
        maxDistance = Mathf.Clamp(distance, minScroll, maxScroll);
    }
}