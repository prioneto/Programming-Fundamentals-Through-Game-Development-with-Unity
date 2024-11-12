using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem
{
    public static Action OnPlayerDeath;
    public static Func<int, int> OnCalculateSore;
}