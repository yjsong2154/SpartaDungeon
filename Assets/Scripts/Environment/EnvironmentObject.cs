using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour, IInteractable
{
    public EnvData data;
    private PlayerCondition condition;
    private PlayerController controller;

    void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        controller = CharacterManager.Instance.Player.controller;
    }

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        for (int i = 0; i < data.modifying.Length; i++)
        {
            switch (data.modifying[i].type)
            {
                case modifyingType.health:
                    condition.Heal(data.modifying[i].value); break;
                case modifyingType.jump:
                    controller.Jump(data.modifying[i].value); break;
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
