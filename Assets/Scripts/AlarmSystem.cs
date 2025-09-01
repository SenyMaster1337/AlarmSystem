using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _changeVolume;

    private float _delay = 0.05f;
    private Trigger _trigger;
    private Coroutine _coroutine;

    public void Init(Trigger trigger)
    {
        _trigger = trigger;

        _trigger.Entered += ActiveateAlarm;
        _trigger.Lefted += DisableAlarm;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void OnDisable()
    {
        _trigger.Entered -= ActiveateAlarm;
        _trigger.Lefted -= DisableAlarm;
    }

    private void StartVolumeCount(float targetVolume)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountVolumeChange(targetVolume));
    }

    private IEnumerator CountVolumeChange(float targetVolume)
    {
        var wait = new WaitForSeconds(_delay);

        while (_audioSource.volume != targetVolume)
        {
            VolumeChange(targetVolume);
            yield return wait;
        }

        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }

    private void VolumeChange(float targetVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeVolume);
    }
 
    private void ActiveateAlarm()
    {
        _audioSource.Play();
        StartVolumeCount(_maxVolume);
    }

    private void DisableAlarm()
    {
        StartVolumeCount(_minVolume);
    }
}
