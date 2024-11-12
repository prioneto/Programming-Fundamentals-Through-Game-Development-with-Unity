using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpListener : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("PlayerJump", RespondToJump);
    }

    void OnDisable()
    {
        EventManager.StopListening("PlayerJump", RespondToJump);
    }

    void RespondToJump()
    {
        Debug.Log("JumpListener: Player has jumped!");
    }
}
