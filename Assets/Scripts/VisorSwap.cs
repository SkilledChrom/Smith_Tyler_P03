using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorSwap : MonoBehaviour
{

    public enum StateMachine
    {
        Combat, Scan, Scanning
    }

    StateMachine currentState;

    public GameObject combatVisor;
    public GameObject scanVisorA;

    public GameObject armCannon;

    void Start()
    {
        currentState = StateMachine.Combat;
        //scanVisorA.SetActive(false);
    }

    void Update()
    {
        switch (currentState)
        {
            case (StateMachine.Combat):
                combatVisor.SetActive(true);
                scanVisorA.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Scan");
                    currentState = StateMachine.Scan;
                }
                break;

            case (StateMachine.Scan):
                combatVisor.SetActive(false);
                scanVisorA.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Scanning");
                    currentState = StateMachine.Scanning;
                }
                break;

            case (StateMachine.Scanning):
                scanVisorA.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Combat");
                    currentState = StateMachine.Combat;
                }
                break;
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
