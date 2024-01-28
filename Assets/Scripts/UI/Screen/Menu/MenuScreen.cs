using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//TODO refactor this
public class MenuScreen : MonoBehaviour
{
    private readonly string INGAME_SCENE_NAME = "InGame";
    [SerializeField] 
    private CanvasGroup _menuScreenCanvas;
    [SerializeField] 
    private CanvasGroup _creditScreenCanvas;
    [SerializeField] 
    private CanvasGroup _optionsScreenCanvas;

    [SerializeField] 
    private string _inGameScene;
    
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button[] _backToMenu;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonPressed);
        _creditsButton.onClick.AddListener(OnCreditsButtonPressed);
        _exitButton.onClick.AddListener(OnExitButtonPressed);
        //_optionsButton.onClick.AddListener(OnOptionsButtonPressed);
        foreach (var backToMenuButton in _backToMenu)
        {
            backToMenuButton.onClick.AddListener(BackToMenuButtonPressed);
        }
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonPressed);
        _creditsButton.onClick.RemoveListener(OnCreditsButtonPressed);
        _exitButton.onClick.RemoveListener(OnExitButtonPressed);
        //_optionsButton.onClick.RemoveListener(OnOptionsButtonPressed);
    }
    

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(INGAME_SCENE_NAME);
    }

    public void OnCreditsButtonPressed()
    {
        DisableCanvasGroup(_menuScreenCanvas);
        EnableCanvasGroup(_creditScreenCanvas);
    }

    public void OnOptionsButtonPressed()
    {
        DisableCanvasGroup(_menuScreenCanvas);
        EnableCanvasGroup(_optionsScreenCanvas);
    }

    public void BackToMenuButtonPressed()
    {
        DisableCanvasGroup(_creditScreenCanvas);
        DisableCanvasGroup(_optionsScreenCanvas);
        EnableCanvasGroup(_menuScreenCanvas);
    }
    
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    private void EnableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
    

    private void DisableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
