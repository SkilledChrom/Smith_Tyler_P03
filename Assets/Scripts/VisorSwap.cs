using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorSwap : MonoBehaviour
{
    public GameObject combatVisor;
    public GameObject scanVisorA;

    public GameObject armCannon;

    void Start()
    {
        scanVisorA.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwapTheVisor();
        }
    }

    void SwapTheVisor()
    {
        Debug.Log("Swapped the Visor.");
        combatVisor.SetActive(false);
        scanVisorA.SetActive(true);
        armCannon.SetActive(false);
    }
}
