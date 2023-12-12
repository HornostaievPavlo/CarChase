using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    public static UnityEvent PlayerLostFromSight = new UnityEvent();

    public static UnityEvent PlayerKilled = new UnityEvent();

    public static UnityEvent LevelFinished = new UnityEvent();

}
