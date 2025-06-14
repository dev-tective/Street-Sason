using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueScripts : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        [TextArea(2, 4)] public string line;
        public bool isLeftSpeaker;
        public string emotionSpriteName; // Nombre del sprite (sin extensión)
    }

    public TextMeshProUGUI leftNameText;
    public TextMeshProUGUI rightNameText;
    public TextMeshProUGUI dialogueText;

    public Image leftCharacterImage;
    public Image rightCharacterImage;

    public DialogueLine[] lines;
    public float textSpeed = 0.05f;

    private int index;
    private bool isTyping = false;
    private bool cancelTyping = false;

    void Start()
    {
        // Ocultar imágenes al inicio
        leftCharacterImage.color = new Color(1, 1, 1, 0);
        rightCharacterImage.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                cancelTyping = true;
            }
            else
            {
                if (index < lines.Length - 1)
                {
                    index++;
                    StartCoroutine(WriteLine());
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        isTyping = true;
        cancelTyping = false;
        dialogueText.text = "";

        DialogueLine currentLine = lines[index];

        if (currentLine.isLeftSpeaker)
        {
            leftNameText.text = currentLine.speakerName;
            rightNameText.text = "";

            if (!string.IsNullOrEmpty(currentLine.emotionSpriteName))
            {
                Sprite newSprite = Resources.Load<Sprite>("Sprites/Personajes/" + currentLine.emotionSpriteName);
                if (newSprite != null)
                {
                    leftCharacterImage.sprite = newSprite;
                    leftCharacterImage.color = Color.white;
                }
                else
                {
                    leftCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar si no se encontró
                }
            }
            else
            {
                leftCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar si no hay sprite
            }

            rightCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar al otro personaje
        }
        else
        {
            rightNameText.text = currentLine.speakerName;
            leftNameText.text = "";

            if (!string.IsNullOrEmpty(currentLine.emotionSpriteName))
            {
                Sprite newSprite = Resources.Load<Sprite>("Sprites/Personajes/" + currentLine.emotionSpriteName);
                if (newSprite != null)
                {
                    rightCharacterImage.sprite = newSprite;
                    rightCharacterImage.color = Color.white;
                }
                else
                {
                    rightCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar si no se encontró
                }
            }
            else
            {
                rightCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar si no hay sprite
            }

            leftCharacterImage.color = new Color(1, 1, 1, 0); // Ocultar al otro personaje
        }

        foreach (char letter in currentLine.line.ToCharArray())
        {
            if (cancelTyping)
            {
                dialogueText.text = currentLine.line;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        leftNameText.text = "";
        rightNameText.text = "";
        leftCharacterImage.color = new Color(1, 1, 1, 0);
        rightCharacterImage.color = new Color(1, 1, 1, 0);
    }
}
