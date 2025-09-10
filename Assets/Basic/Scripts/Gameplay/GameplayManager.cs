using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private string _mainMenuSceneName;
    
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
        SceneManager.LoadScene(_mainMenuSceneName);
    }
}
