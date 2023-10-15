using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPont;

    private void Awake()
    {
        Instantiate(_ball, _spawnPont.position, Quaternion.identity);
    }
}
