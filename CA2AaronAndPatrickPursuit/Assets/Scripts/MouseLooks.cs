using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooks : MonoBehaviour
{
    private GameObject player;
    public float minClamp = -45;
    public float maxClamp = 45;
    [HideInInspector]
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0,0);
    public float lookSensitivity = 2;
    public float lookSmoothDamp = 0.1f;

    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);

        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);

        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);
    }
}
