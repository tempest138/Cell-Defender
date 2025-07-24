using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechManager : MonoBehaviour
{

    [SerializeField] private float typeSpeed = .05f;

    [SerializeField] private TextMeshProUGUI npcText;

    [SerializeField] private GameObject continueButton;

    [TextArea]
    [SerializeField] private string[] speechSentences;

    private int npcIndex;

    private void Start()
    {
        startSpeech();
    }

    public void startSpeech()
    {
        StartCoroutine(typeSpeech());
    }

    private IEnumerator typeSpeech()
    {
        foreach(char letter in speechSentences[npcIndex].ToCharArray())
        {
            npcText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        continueButton.SetActive(true);

    }

    public void continueSpeech()
    {
        continueButton.SetActive(false);
        
        if(npcIndex < speechSentences.Length - 1)
        {
            npcIndex++;

            npcText.text = string.Empty;
            StartCoroutine(typeSpeech());
        }
    }
}
