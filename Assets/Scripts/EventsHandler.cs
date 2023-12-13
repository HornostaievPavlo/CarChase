using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    public static UnityEvent LevelFailed = new UnityEvent();

}
