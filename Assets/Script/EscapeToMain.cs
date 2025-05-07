using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Mainmap");
        }
    }
}