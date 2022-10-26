using UnityEngine;

public class EventOnClickScreen : MonoBehaviour, IEvent
{
    public void OnClickScreen()
    {
        EventDispatcher.Instance.Invoke<EventOnClickScreen>();
    }
}
