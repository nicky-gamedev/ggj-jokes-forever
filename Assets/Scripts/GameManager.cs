// using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private ScreenManager _screenManager;
    [SerializeField] 
    public TitleScreen _titleScreen;
    [SerializeField] 
    private Health _characterHealth;

    private void OnEnable()
    {
        _characterHealth.OnHealthDepleted += OnPlayerDie;
    }

    void Start()
    {
        _screenManager.GetScreen<DialogScreen>().Show();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterMovement>())
        {
            _titleScreen.OnVictory();
        }
    }

    private void OnPlayerDie()
    {
        _titleScreen.OnGameOver();
    }
        
    
}
