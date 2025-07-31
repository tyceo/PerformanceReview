using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UITimeManager : MonoBehaviour
{
    public static UITimeManager Instance { get; private set; }

    [Header("Time Settings")]
    [SerializeField] private float realSecondsPerGameMinute = 1f;
    [SerializeField] private int startHour = 9;
    [SerializeField] private int startMinute = 0;
    [SerializeField] private int endHour = 17; // 5 PM
    [SerializeField] private int endMinute = 0;

    [Header("UI References")]
    [SerializeField] private TMP_Text timeText;

    public UnityEvent OnWorkDayEnded;

    private float currentTimeInSeconds;
    private int currentHour;
    private int currentMinute;
    private bool isWorkDayOver = false;
    private int totalMinutesPassed = 0;
    private int endTimeInMinutes;

    public GameObject FivePMBanner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeTime();
    }

    private void InitializeTime()
    {
        currentHour = startHour;
        currentMinute = startMinute;
        currentTimeInSeconds = 0;
        totalMinutesPassed = 0;
        endTimeInMinutes = endHour * 60 + endMinute;
        UpdateTimeDisplay();
    }

    private void Update()
    {
        if (isWorkDayOver) return;

        currentTimeInSeconds += Time.deltaTime;

        // Calculate total minutes passed in game time
        int newTotalMinutes = Mathf.FloorToInt(currentTimeInSeconds / realSecondsPerGameMinute);

        // Only update if minutes have changed
        if (newTotalMinutes > totalMinutesPassed)
        {
            totalMinutesPassed = newTotalMinutes;

            // Calculate current hour and minute
            int totalTime = startHour * 60 + startMinute + totalMinutesPassed;
            currentHour = (totalTime / 60) % 24;
            currentMinute = totalTime % 60;

            UpdateTimeDisplay();

            // Check if we've reached end time
            if (totalTime >= endTimeInMinutes)
            {
                EndWorkDay();
            }
        }
    }

    private void UpdateTimeDisplay()
    {
        string period = currentHour < 12 ? "AM" : "PM";
        int displayHour = currentHour > 12 ? currentHour - 12 : currentHour;
        if (displayHour == 0) displayHour = 12;
        timeText.text = $"{displayHour:00}:{currentMinute:00} {period}";
    }

    private void EndWorkDay()
    {
        isWorkDayOver = true;
        Debug.Log($"Work day ended! It's {endHour:00}:{endMinute:00}!");
        OnWorkDayEnded.Invoke();
        FivePMBanner.SetActive(true);
    }

    public void SetTime(int hour, int minute)
    {
        int newTotalMinutes = hour * 60 + minute;
        int startTimeInMinutes = startHour * 60 + startMinute;

        currentTimeInSeconds = (newTotalMinutes - startTimeInMinutes) * realSecondsPerGameMinute;
        totalMinutesPassed = Mathf.Max(0, newTotalMinutes - startTimeInMinutes);

        currentHour = hour;
        currentMinute = minute;

        UpdateTimeDisplay();

        if (!isWorkDayOver && newTotalMinutes >= endTimeInMinutes)
        {
            EndWorkDay();
        }
    }

    public (int hour, int minute) GetCurrentTime()
    {
        return (currentHour, currentMinute);
    }
}