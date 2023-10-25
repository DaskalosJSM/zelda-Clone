using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BugFixing : MonoBehaviour
{
    private PlayerInput _playerInputMap;
    // Start is called before the first frame update
    void Start()
    {
        _playerInputMap = GetComponent<PlayerInput>();
        // bug Fix
        _playerInputMap.enabled = false;
        _playerInputMap.enabled = true;
    }
}
