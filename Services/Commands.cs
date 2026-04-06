using System;

namespace WemosClock.Services;

/// <summary>
/// Класс для формирования команд управления часами
/// </summary>
public class Commands{

    /// <summary>
    /// Преобразует день недели в команду
    /// для настройки дня недели в часах
    /// </summary>
    /// <param name="weekDay"></param>
    /// <returns></returns>
    private string SetCmdDay(string weekDay){

        string day = string.Empty; 
        switch (weekDay){
            case "Monday": day = "set13"; break; 
            case "Tuesday": day = "set23"; break;
            case "Wednesday": day = "set33"; break;
            case "Thursday": day = "set43"; break;
            case "Friday": day = "set53"; break;
            case "Saturday": day = "set63"; break;
            case "Sunday": day = "set73"; break;
        }
        return day;
    }

    /// <summary>
    /// Преобразует системное время в команду 
    /// для установки времени в часах
    /// </summary>
    /// <returns></returns>
    public string GetSystemTime()
    {
        var now = DateTime.Now;
        string time = now.ToString("HHmmss");
        return $"set{time}1";
    }

    /// <summary>
    /// Преобразует год, месяц, число в команду для
    /// установки даты в часах
    /// </summary>
    /// <returns></returns>
    public string GetSystemDate()
    {
        var now = DateTime.Now;
        string year = now.Year.ToString();
        string month = now.Month.ToString("D2");
        string day = now.Day.ToString("D2");
        return $"set{year[2..]}{month}{day}2";
    }
}