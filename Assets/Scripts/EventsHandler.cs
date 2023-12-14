using UnityEngine;
using UnityEngine.Events;

public static class EventsHandler
{
    public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    public static UnityEvent CoinCollected = new UnityEvent();

    public static UnityEvent HealthPointCollected = new UnityEvent();

    public static UnityEvent<Vector3> PlayerCrushed = new UnityEvent<Vector3>();

    public static UnityEvent LevelFailed = new UnityEvent();

    public static void OnPlayerHealthUpdated(float changePercent) => PlayerHealthUpdated.Invoke(changePercent);

    public static void OnCoinCollected() => CoinCollected.Invoke();

    public static void OnHealthPointCollected() => HealthPointCollected.Invoke();

    public static void OnPlayerCrushed(Vector3 position) => PlayerCrushed.Invoke(position);

    public static void OnLevelFailed() => LevelFailed.Invoke();
}
