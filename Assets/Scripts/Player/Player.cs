using System;
using UnityEngine;

// Player와 관련된 기능을 모아두는 곳.
// 이곳을 통해 기능에 각각 접근. (ex.CharacterManager.Instance.Player.controller)
public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action useItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}