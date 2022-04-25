using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalC : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] itemInfo = null;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText = null;
    private int currentDisplayingText = 0;

    public void ScanTerminalC()
    {
        StartCoroutine(AnimateText());
        Debug.Log("Among Us");
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
