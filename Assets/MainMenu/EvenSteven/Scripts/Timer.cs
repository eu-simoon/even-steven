using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    // Поле со ссылкой на компонент, отвечающий за отображение времени
    [SerializeField] private TimerView _view;

    // Поле с лимитом времени для отсчёта таймера в секундах
    [SerializeField] private float _startTime = 10f;

    // Поле с интервалом, с которым происходит отсчёт времени
    [SerializeField] private float _countdownInterval = 0.1f;

    // Поле со ссылкой на событие, которое будет вызвано при окончании отсчёта времени
    [SerializeField] private UnityEvent _timerFinished;

    // Поле со ссылкой на запущенную сопрограмму
    private Coroutine _coroutine;

    // Свойство возвращает true, если таймер запущен, иначе false
    public bool IsTimerRunning => _coroutine != null;

    /// Метод остановки таймера
    public void Stop()
    {
        // Останавливаем сопрограмму, если она запущена
        StopCoroutineIfActive();
    }

    
    /// Метод перезапуска таймера
    public void Restart()
    {
        // Останавливаем сопрограмму, если она запущена
        StopCoroutineIfActive();
        // Запускаем новую сопрограмму для отсчёта времени
        StartNewCoroutine();
    }

    /// Метод останавливает сопрограмму, если она запущена
    private void StopCoroutineIfActive()
    {
        // Если сопрограмма запущена
        if (IsTimerRunning)
        {
            // Останавливаем сопрограмму
            StopCoroutine(_coroutine);
            // Очищаем ссылку на сопрограмму
            _coroutine = null;
        }
    }

    /// Метод запускает новую сопрограмму
    private void StartNewCoroutine()
    {
        // Запускаем сопрограмму и сохраняем ссылку на неё
        _coroutine = StartCoroutine(CountdownTime(_startTime, _countdownInterval));
    }

    /// Сопрограмма отсчитывает время с заданным интервалом
    /// <param name="startTime">Интервал времени, который отсчитывает таймер</param>
    /// <param name="countdownInterval">Интервал, c которым отсчитывается время</param>
    private IEnumerator CountdownTime(float startTime, float countdownInterval)
    {
        // Объявляем переменную для хранения оставшегося времени
        float remainingTime = startTime;

        // Создаём объект WaitForSeconds с указанным интервалом времени
        WaitForSeconds waitInterval = new WaitForSeconds(countdownInterval);

        // Цикл будет выполняться, пока не истечёт отведённое время
        do
        {
            // Ожидаем указанный интервал
            yield return waitInterval;
            // Вычитаем интервал из оставшегося времени
            remainingTime -= countdownInterval;
            // Метод Mathf.Max возвращает наибольшее из двух чисел,
            // если значение remainingTime меньше нуля, метод вернёт 0
            // Таким образом, значение remainingTime не будет отрицательным
            remainingTime = Mathf.Max(remainingTime, 0f);
            // Отображаем текущее состояние таймера
            DisplayTime(startTime, remainingTime);
        }
        // Цикл продолжается, пока остаётся время
        while (remainingTime > 0);

        // После завершения цикла очищаем ссылку на сопрограмму,
        // так как сопрограмма завершает свою работу
        _coroutine = null;
        // Вызываем событие, сообщаем о том, что таймер завершил отсчёт
        _timerFinished.Invoke();
    }

    /// Метод передаёт текущие значения состояния таймера для отображения на экране
    /// <param name="startTime">Интервал времени, который отсчитывает таймер</param>
    /// <param name="remainingTime">Оставшееся время, которое осталось отсчитать</param>
    private void DisplayTime(float startTime, float remainingTime)
    {
        // Вызываем метод Display и передаём значение аргументов метода
        // startTime время начала отсчёта и remainingTime оставшееся время
        _view.Display(startTime, remainingTime);
    }
}
