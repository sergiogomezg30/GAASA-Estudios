using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject uiDialogue;
    private GameObject dialoguePanel;
    private Image image1, image2;

    private string npcName;
    private List<string> dialogueLines = new List<string>();
    private SpriteRenderer npcSprite;

    private Button continueButton;
    private Text dialogueText, nameText;
    private int dialogueIndex;

    private bool isTyping;

    public int framesEntreLetras = 3;
    private bool hardcode = false;  //booleano para poder meter dialogos sin sistema de interacciones

    [SerializeField] private InteractionsHandler interactionsHandler;
    [SerializeField] private SpriteRenderer playerSprite;

    void Awake()
    {
        image1 = uiDialogue.transform.GetChild(1).GetComponent<Image>();
        image2 = uiDialogue.transform.GetChild(2).GetComponent<Image>();

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

    public void AddNewDialogue(string[] lines, string npcName, SpriteRenderer npcSprite, bool hardcode = false)
    {
        dialogueIndex = 0;

        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.npcName = npcName;
        this.npcSprite = npcSprite;

        this.hardcode = hardcode;

        Debug.Log(dialogueLines.Count + "lines");
        if (!hardcode)
            CreateDialogue();
        else
            CreateDialogue2();
    }
    
    private void CreateDialogue()
    {
        dialogueText.text = "";
        nameText.text = npcName;

        image1.sprite = playerSprite.sprite;
        image2.sprite = npcSprite.sprite;

        float relation1 = image1.sprite.rect.height / image1.sprite.rect.width;
        float relation2 = image2.sprite.rect.height / image2.sprite.rect.width;

        image1.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, relation1 * 100);
        image2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, relation2 * 100);

        if (!playerSprite.gameObject.GetComponent<controlPersonaje>().originImageMirandoDer)    //si esta mirando a la izq que mire a la der
            image1.gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        if (npcSprite.gameObject.GetComponent<NPC>().originImageMirandoDer)        //si esta mirando a la der que mire a la izq
            image2.gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);

        uiDialogue.SetActive(true);

        StartCoroutine(TypeSentence());
    }
    private void CreateDialogue2()
    {
        dialogueText.text = "";
        nameText.text = npcName;

        image1.sprite = playerSprite.sprite;
        image2.sprite = npcSprite.sprite;

        float relation1 = image1.sprite.rect.height / image1.sprite.rect.width;
        float relation2 = image2.sprite.rect.height / image2.sprite.rect.width;

        image1.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, relation1 * 100);
        image2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, relation2 * 100);

        //if (!playerSprite.gameObject.GetComponent<controlPersonaje>().originImageMirandoDer)    //si esta mirando a la izq que mire a la der
            image1.gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        //if (npcSprite.gameObject.GetComponent<NPC>().originImageMirandoDer)        //si esta mirando a la der que mire a la izq
            //image2.gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);

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

        if (!hardcode) {
            interactionsHandler.InteractionFinished();
        }
        StopAllCoroutines();    //en el caso de que hayamos saltado el texto y volvamos a empezarlo

        //resetear el escalado porsi
        image1.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        image2.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        GameEvents.Instance.FinishDialogue(npcName);
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
