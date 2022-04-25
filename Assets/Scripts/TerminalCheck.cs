using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCheck : MonoBehaviour
{
    [SerializeField] Camera _cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float _shootDistance = 15f;

    public string terminalTag;

    RaycastHit _objectHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FireCheck();
        }
    }

    void FireCheck()
    {
        Vector3 rayDirection = _cameraController.transform.forward;

        Debug.DrawRay(rayOrigin.position, rayDirection * _shootDistance, Color.blue, 1f);
        if (Physics.Raycast(rayOrigin.position, rayDirection, out _objectHit, _shootDistance))
        {
            Debug.Log("You hit the " + _objectHit.transform.name);

            terminalTag = _objectHit.transform.tag;

            switch (terminalTag)
            {
                case ("TypeA"):
                    Debug.Log("Type A is functional");
                    break;
                case ("TypeB"):
                    Debug.Log("Type B is functional");
                    break;
                case ("TypeC"):
                    Debug.Log("Type C is functional");
                    break;
            }
        }
    }
}
