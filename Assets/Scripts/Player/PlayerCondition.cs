using System;
using System.Collections;
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
        Coroutine boostCoroutine = StartCoroutine(BoostCoroutine(amount, 3f));
    }

    private IEnumerator BoostCoroutine(float amount, float duration)
    {
        float originalSpeed = Speed;  // 원래 속도 저장
        Speed = MathF.Max(1, Speed + amount);  // 속도 증가
        CharacterManager.Instance.Player.controller.moveSpeed = Speed; // 적용

        yield return new WaitForSeconds(duration);  // 3초 대기

        Speed = originalSpeed;  // 원래 속도로 복구
        CharacterManager.Instance.Player.controller.moveSpeed = Speed; // 다시 적용
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