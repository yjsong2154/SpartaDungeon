using System;
using UnityEngine;

// Player와 관련된 기능을 모아두는 곳.
// 이곳을 통해 기능에 각각 접근. (ex.CharacterManager.Instance.Player.controller)
public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
    }
}