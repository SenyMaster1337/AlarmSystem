using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxValume;
    [SerializeField] private float _changeVolume;

    private bool _isAlarmActivated = false;

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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            _isAlarmActivated = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            _isAlarmActivated = false;
        }
    }
}
