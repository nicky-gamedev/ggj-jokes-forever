using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PieController : MonoBehaviour
{
    [SerializeField] private Image _splashScreen;
    [SerializeField] private SpriteRenderer _gun;
    [SerializeField] private SpriteRenderer _pie;
    [SerializeField] private int _ammoReward;
    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private int _healthReward;
    [SerializeField] private Health _health;
    [SerializeField] private InputReader _inputReader;

    public event Action OnAnimationStart = delegate { };
    public event Action OnAnimationEnd = delegate { };

    private void OnEnable()
    {
        _inputReader.PieEvent += () => StartCoroutine(PlayAnimation());
    }

    private void OnDisable()
    {
        _inputReader.PieEvent -= () => StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        OnAnimationStart();
        _gun.gameObject.SetActive(false);
        _pie.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayOneShot("pie", 0);
        _splashScreen.color = Color.white;
        _pie.gameObject.SetActive(false);
        _gun.gameObject.SetActive(true);
        _splashScreen.DOColor(Color.clear, 1f).SetEase(Ease.InExpo).onComplete += () =>
        {
            _weapon.CurrentAmmo.AddAmmo(_ammoReward);
            _health.AddHealth(_healthReward);
            AudioManager.Instance.PlayOneShot("reload", 0);
        };
    }
}