using UnityEngine;

// 개별 Condition 바의 조합으로 이루어진 UICondition
public class UICondition : MonoBehaviour
{
    public Condition health;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}