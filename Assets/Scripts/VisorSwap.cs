using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject terminalA;
    public GameObject terminalB;
    public GameObject terminalC;
    public GameObject backupTerminalA;
    public GameObject backupTerminalB;

    public AudioSource forwardMenu;
    public AudioSource backMenu;

    TerminalCheck terminalCheck;

    [SerializeField] private TextMeshProUGUI itemInfoText = null;

    public GameObject armCannon;

    void Start()
    {
        currentState = StateMachine.Combat;
        terminalCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TerminalCheck>();
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

                terminalA.SetActive(false);
                terminalB.SetActive(false);
                terminalC.SetActive(false);
                backupTerminalA.SetActive(false);
                backupTerminalB.SetActive(false);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Scan");
                    currentState = StateMachine.Scan;
                    forwardMenu.Play();
                }
                break;

            case (StateMachine.Scan):
                combatVisor.SetActive(false);
                armCannon.SetActive(false);
                scanVisorA.SetActive(true);
                scanVisorB.SetActive(false);

                terminalA.SetActive(true);
                terminalB.SetActive(true);
                terminalC.SetActive(true);
                backupTerminalA.SetActive(true);
                backupTerminalB.SetActive(true);

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    terminalCheck.FireCheck();
                    //Debug.Log("Changing to Scanning");
                    currentState = StateMachine.Scanning;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Changing to Combat");
                    currentState = StateMachine.Combat;
                    backMenu.Play();
                }
                break;

            case (StateMachine.Scanning):
                scanVisorA.SetActive(false);
                scanVisorB.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;

                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Debug.Log("Changing to Scan");
                    Time.timeScale = 1;
                    itemInfoText.text = "";
                    currentState = StateMachine.Scan;
                    backMenu.Play();
                }
                break;
        }
    }
}
