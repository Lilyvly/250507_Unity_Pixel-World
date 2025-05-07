using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInteraction : MonoBehaviour
{
    public GameObject interactUI;       
    public Button playButton;           
    public string miniGameSceneName = "MiniGameScene";

    private bool isPlayerNearby = false;

    void Start()
    {
        interactUI.SetActive(false);
        playButton.gameObject.SetActive(false);

        // 버튼에 클릭 이벤트 연결
        playButton.onClick.AddListener(LoadMiniGame);
    }

    void Update()
    {
        // ESC로 돌아가기 처리 (미니게임 씬일 때)
        if (SceneManager.GetActiveScene().name == miniGameSceneName && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMap"); 
        }
    }

    void LoadMiniGame()
    {
        SceneManager.LoadScene(miniGameSceneName);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            playButton.gameObject.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            playButton.gameObject.SetActive(false);
            isPlayerNearby = false;
        }
    }
}
