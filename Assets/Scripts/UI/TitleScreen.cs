using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _backButton;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButton);
    }

    public void OnBackButton()
   {
       SceneManager.LoadScene("MainMenu");
   }

   public void OnGameOver()
   {
       _canvasGroup.alpha = 1;
       _canvasGroup.interactable = true;
       _canvasGroup.blocksRaycasts = true;
       _text.text = "GAME OVER";
       Cursor.visible = true;
   }

   public void OnVictory()
   {
       _canvasGroup.alpha = 1;
       _canvasGroup.interactable = true;
       _canvasGroup.blocksRaycasts = true;
       _text.text = "CONGRATULATIONS. DEMO COMPLETED";
       Cursor.visible = true;
   }
}
