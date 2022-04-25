using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalA : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] itemInfo = null;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText = null;
    private int currentDisplayingText = 0;

    public void ScanTerminalA()
    {
        StartCoroutine(AnimateText());
        Debug.Log("Good fucking Lord");
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
