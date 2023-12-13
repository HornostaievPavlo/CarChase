using UnityEngine;
using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    public static UnityEvent MagnetActivated = new UnityEvent();

    public static UnityEvent CoinCollected = new UnityEvent();

    public static UnityEvent HealthPointCollected = new UnityEvent();

    public static UnityEvent LevelFailed = new UnityEvent();

    public static void OnMagnetActivated() => MagnetActivated.Invoke();

    public static void OnCoinCollected() => CoinCollected.Invoke();

    public static void OnHealthPointCollected() => HealthPointCollected.Invoke();

    public static void OnLevelFailed() => LevelFailed.Invoke();
}
