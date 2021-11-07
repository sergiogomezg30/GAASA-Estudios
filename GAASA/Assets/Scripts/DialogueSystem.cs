using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;
    public GameObject dialoguePanel;

    private string npcName;
    private List<string> dialogueLines = new List<string>();

    private Button continueButton;
    private Text dialogueText, nameText;
    private int dialogueIndex;

    private bool isTyping;

    //falta por poner las referencias al script de control del personaje para inhabilitar todo mientras estamos hablando
    //[SerializeField] private InteractionsHandler interactionsHandler;
    public int framesEntreLetras = 3;

    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        isTyping = false;

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;

        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.npcName = npcName;

        Debug.Log(dialogueLines.Count + "lines");
        CreateDialogue();
    }
    
    private void CreateDialogue()
    {
        dialogueText.text = "";
        nameText.text = npcName;

        dialoguePanel.SetActive(true);

        StartCoroutine(TypeSentence());
    }

    private void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1) {
            dialogueIndex++;
            StopAllCoroutines();
            StartCoroutine(TypeSentence());
        }
        else {
            FinishDialogue();
        }
    }

    private void FinishDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in dialogueLines[dialogueIndex].ToCharArray()) {
            dialogueText.text += letter;

            for (int frames = 0; frames < framesEntreLetras; frames++) {
                yield return null;
            }
        }

        isTyping = false;
    }
}