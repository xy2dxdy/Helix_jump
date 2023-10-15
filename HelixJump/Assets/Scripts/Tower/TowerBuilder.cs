using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => _levelCount + _startAndFinishAdditionalScale + _additionalScale;
    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform.position, Quaternion.identity, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;
        SpawnPlatform(_startPlatform, ref spawnPosition, beam.transform);
        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3  spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 2;
    }
}
