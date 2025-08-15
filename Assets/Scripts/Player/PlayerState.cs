using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float damage;
    [SerializeField]
    private Slider playerHPBar;

    public float Damage => damage;
    public float CurrentHP
    {
        get => currentHP;
        set => currentHP = value;
    }

    private void Update()
    {
        PlayerHPBar();
    }

    private void PlayerHPBar()
    {
        playerHPBar.value = currentHP / maxHP;
    }
}
