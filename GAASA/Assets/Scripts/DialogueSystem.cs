using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject uiDialogue;
    private GameObject dialoguePanel;

    private string npcName;
    private List<string> dialogueLines = new List<string>();

    private Button continueButton;
    private Text dialogueText, nameText;
    private int dialogueIndex;

    private bool isTyping;

    public int framesEntreLetras = 3;

    [SerializeField] private InteractionsHandler interactionsHandler;

    void Awake()
    {
        dialoguePanel = uiDialogue.transform.Find("Dialogue").gameObject;

        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        uiDialogue.SetActive(false);

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

        uiDialogue.SetActive(true);

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
        uiDialogue.SetActive(false);

        interactionsHandler.InteractionFinished();
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
