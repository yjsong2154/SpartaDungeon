using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    public event Action onTakeDamage;   // Damage 받을 때 호출할 Action

    public float Speed;

    private void Start()
    {
        Speed = CharacterManager.Instance.Player.controller.moveSpeed;
    }

    private void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);

        if (health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Boost(float amount)
    {
        Speed = MathF.Max(1, Speed + amount);
        CharacterManager.Instance.Player.controller.moveSpeed = Speed;
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}