using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventChannelSO", menuName = "Game/ChannelsSO")]
public class EventChannelSO : ScriptableObject
{
    public UnityEvent EventChannel;
}
