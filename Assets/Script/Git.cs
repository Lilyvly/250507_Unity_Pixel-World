using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GitInteraction : MonoBehaviour
{
    public string gitHubLink = "https://github.com/Lilyvly";
    public GameObject talkbutton;   // "대화하기" 버튼 포함된 UI 오브젝트
    public GameObject dialogueUI;   // 대화창 UI
    public TextMeshProUGUI dialogueText;

    private bool isPlayerNearby = false;
    private bool isDialogueOpen = false;

    void Start()
    {
        talkbutton.SetActive(false);
        dialogueUI.SetActive(false);

        // 버튼에 이벤트 연결
        Button button = talkbutton.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ToggleDialogue);
        }
        else
        {
            Debug.LogWarning("talkbutton 안에 Button 컴포넌트가 없습니다!");
        }
    }

    void ToggleDialogue()
    {
        isDialogueOpen = !isDialogueOpen;
        dialogueUI.SetActive(isDialogueOpen);

        if (isDialogueOpen)
        {
            dialogueText.text = $"Did you know this? \n{gitHubLink}";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkbutton.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkbutton.SetActive(false);
            dialogueUI.SetActive(false);
            isPlayerNearby = false;
            isDialogueOpen = false;
        }
    }
}
