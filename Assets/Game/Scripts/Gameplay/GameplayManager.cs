using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    
    private void Start()
    {
        _inputManager.OnMainMenuInput += BackToMainMenu;
    }
 
    private void OnDestroy()
    {
        _inputManager.OnMainMenuInput -= BackToMainMenu;
    }
    
    private void BackToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
