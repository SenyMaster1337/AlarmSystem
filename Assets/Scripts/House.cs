using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void Awake()
    {
        _alarmSystem.Init(_trigger);
    }
}
