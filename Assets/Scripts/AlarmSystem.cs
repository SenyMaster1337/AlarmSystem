using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxValume;
    [SerializeField] private float _changeVolume;

    private bool _isAlarmActivated = false;

    private void OnEnable()
    {
        _house.HouseEntered += ActiveateAlarm;
        _house.HouseLefted += DisableAlarm;
    }

    private void OnDisable()
    {
        _house.HouseEntered -= ActiveateAlarm;
        _house.HouseLefted -= DisableAlarm;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_isAlarmActivated == true && _audioSource.volume != _maxValume)
        {
            _audioSource.volume += Mathf.MoveTowards(_minVolume, _maxValume, _changeVolume);
        }
        else if (_audioSource.volume != _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _changeVolume);
        }
    }

    private void ActiveateAlarm()
    {
        _isAlarmActivated = true;
        _audioSource.Play();
    }

    private void DisableAlarm()
    {
        _isAlarmActivated = false;
    }
}
