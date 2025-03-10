using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    private PlayerCondition condition;

    void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
    }

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        for (int i = 0; i < data.consumables.Length; i++)
        {
            switch (data.consumables[i].type)
            {
                case ConsumableType.health:
                    condition.Heal(data.consumables[i].value); break;
                case ConsumableType.Speed:
                    condition.Boost(data.consumables[i].value); break;
            }
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnInteract();
        }
    }
}