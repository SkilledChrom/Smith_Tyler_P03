using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalCheck : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] itemInfo = null;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText = null;
    private int currentDisplayingText = 0;

    [SerializeField] Camera _cameraController = null;
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] float _shootDistance = 30f;

    public GameObject buttonA;
    public GameObject targetHit;

    public string terminalTag;

    RaycastHit _objectHit;

    public void FireCheck()
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
                    _objectHit.collider.GetComponent<TerminalA>().ScanTerminalA();
                    Debug.Log("Type A is functional");
                    break;
                case ("TypeB"):
                    _objectHit.collider.GetComponent<TerminalB>().ScanTerminalB();
                    Debug.Log("Type B is functional");
                    break;
                case ("TypeC"):
                    _objectHit.collider.GetComponent<TerminalC>().ScanTerminalC();
                    Debug.Log("Type C is functional");
                    break;
                default:
                    StartCoroutine(AnimateText());
                    break;
            }
        }
        else
        {
            StartCoroutine(AnimateText());
        }
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
        {
            itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
}
