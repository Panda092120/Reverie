using System;
using UnityEngine;
using UnityEngine.UI;

public class DaySystem : MonoBehaviour
{
    public static DaySystem Instance { get; private set; }
    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }


    // Enums for time of day and weekdays
    public enum TimeOfDay { Morning, Afternoon, Night }
    public enum WeekDay { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }

    // Variables for the current day, month, year, and time of day
    public int day = 20;
    public int month = 8;  // Starting in April, for example
    public int year = 2024;
    public TimeOfDay currentTimeOfDay = TimeOfDay.Morning;
    public WeekDay currentWeekDay = WeekDay.Monday;

    // Days in each month (could modify for leap years if needed)
    private int[] daysInMonth = { 31, 31, 30, 31, 30, 31, 30, 31, 31, 30, 31, 30, };  // August to April example

    // UI elements to display date and time of day
    public Text dateText;
    public Text timeOfDayText;

    // Scheduled events
    [System.Serializable]
    public class ScheduledEvent
    {
        public int day;
        public int month;
        public TimeOfDay timeOfDay;
        public string eventName;

        public void TriggerEvent()
        {
            Debug.Log($"Event triggered: {eventName} on {month}/{day} during {timeOfDay}");
        }
    }

    public ScheduledEvent[] events;  // Array of events to trigger on specific days

    // Start method to initialize the system
    private void Start()
    {
        UpdateUI();  // Update the UI at the start of the game
    }

    // Update method to check for player input to advance time (e.g., press spacebar)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceTime();
        }
    }

    // Method to advance the time of day and eventually the day
    public void AdvanceTime()
    {
        // Advance the time of day
        currentTimeOfDay++;
        if (currentTimeOfDay > TimeOfDay.Night)
        {
            currentTimeOfDay = TimeOfDay.Morning;
            NextDay();  // If it reaches night, go to the next day
        }

        HandleEvents();  // Check for any events that should trigger at this time
        UpdateUI();  // Update the UI after advancing time
    }

    // Method to move to the next day
    private void NextDay()
    {
        day++;

        // Check if we've reached the end of the month
        if (day > daysInMonth[month - 1])
        {
            day = 1;  // Reset to the 1st day of the next month
            month++;

            // Check if we've reached the end of the year
            if (month > 12)
            {
                month = 1;  // Reset to January
                year++;
            }
        }

        // Advance the weekday
        currentWeekDay++;
        if (currentWeekDay > WeekDay.Saturday)
        {
            currentWeekDay = WeekDay.Sunday;
        }
    }

    // Method to handle event triggers based on the current time and date
    private void HandleEvents()
    {
        foreach (var scheduledEvent in events)
        {
            if (scheduledEvent.day == day && scheduledEvent.month == month && scheduledEvent.timeOfDay == currentTimeOfDay)
            {
                scheduledEvent.TriggerEvent();  // Trigger the event if the day and time match
            }
        }
    }

    // Method to update the UI with the current day and time of day
    private void UpdateUI()
    {
        dateText.text = $"Day: {day}/{month}/{year} ({currentWeekDay})";
        timeOfDayText.text = $"Time: {currentTimeOfDay}";
    }
}
