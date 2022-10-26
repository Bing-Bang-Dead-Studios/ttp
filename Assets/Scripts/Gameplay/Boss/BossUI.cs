using System;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : UiElement
{
    [SerializeField] private Image _bossLife;
    private BossService _bossService;

    private void Start()
    {
        _bossService = ServiceLocator.Instance.Get<BossService>();
        EventDispatcher.Instance.AddListener<EventOnClickScreen>(this, onClickScreen);
    }

    public void SetBossLife()
    {
        _bossLife.fillAmount = _bossService.GetBossCurrentLife() / _bossService.GetBossMaxLife();
    }

    public void onClickScreen()
    {
        SetBossLife();
    }
}
