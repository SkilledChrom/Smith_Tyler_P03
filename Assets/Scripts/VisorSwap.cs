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
    public GameObject scanVisorB;

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
                armCannon.SetActive(true);
                scanVisorA.SetActive(false);
                scanVisorB.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Scan");
                    currentState = StateMachine.Scan;
                }
                break;

            case (StateMachine.Scan):
                combatVisor.SetActive(false);
                armCannon.SetActive(false);
                scanVisorA.SetActive(true);
                scanVisorB.SetActive(false);
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Debug.Log("Changing to Scanning");
                    currentState = StateMachine.Scanning;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Combat");
                    currentState = StateMachine.Combat;
                }
                break;

            case (StateMachine.Scanning):
                scanVisorA.SetActive(false);
                scanVisorB.SetActive(true);
                Time.timeScale = 0;
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    Debug.Log("Changing to Scan");
                    Time.timeScale = 1;
                    currentState = StateMachine.Scan;
                }
                break;
        }
    }
}
