﻿using System;
using Game.Level.Unit;
using UnityEngine;

public sealed class PlayerView : UnitStaffView
{
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private string _currentState;

    public Vector3 AimPosition => _aimTransform.position;

    public Type CurrentState
    {
        set => _currentState = value?.Name;
    }
}