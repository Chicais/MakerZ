using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    public static MainCanvasManager Instance;
    
    [SerializeField] private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas => _lobbyCanvas;

    [SerializeField] private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas => _currentRoomCanvas;

    private void Awake()
    {
        Instance = this;
    }
}
