using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    // Поле со ссылкой на элемент интерфейса слайдер (Slider)
    [SerializeField] private Slider _timerSlider;

    /// Метод отображает текущее состояние таймера
    /// <param name="startTime">Максимальное время таймера</param>
    /// <param name="remainingTime">Текущее время таймера</param>

    public void Display(float startTime, float remainingTime)
    {
        // Находим отношение оставшегося времени к начальному времени
        // Это значение от 0 до 1, где
        // 0 — это 0% оставшегося времени
        // 1 — это 100%
        float progress = remainingTime / startTime;
        // Присваиваем свойству value полученное значение
        // для отображения полосы прогресса
        _timerSlider.value = progress;
    }
}
