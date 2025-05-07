using UnityEngine;
using UnityEngine.UI;

public class TalkUIController : MonoBehaviour
{
    public GameObject talkButton;
    public GameObject dialogPanel;

    private void Start()
    {
        talkButton.SetActive(false);
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkButton.SetActive(false);
            dialogPanel.SetActive(false);
        }
    }

    public void OnTalkButtonClick()
    {
        dialogPanel.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        dialogPanel.SetActive(false);
    }
}
