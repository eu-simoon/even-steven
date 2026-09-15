using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Класс отвечает за генерацию числа и обработку ответов пользователя

public class NumberParity : MonoBehaviour
{
    // Поле со ссылкой на компонент отображения числа
    [SerializeField] private NumberParityView _view;

    // Поле со ссылкой на компонент, подсчитывающий правильные ответы
    [SerializeField] private AnswerTracker _correctTracker;

    // Поле со ссылкой на компонент, подсчитывающий неправильные ответы
    [SerializeField] private AnswerTracker _incorrectTracker;

    // Поле с нижней границей диапазона для случайного числа
    [SerializeField] private int _lowerBound = 1;

    // Поле с верхней границей диапазона для случайного числа
    [SerializeField] private int _upperBound = 100;

    // Случайное число
    private int _number;

    // Флаг активности игры
    private bool _isGameActive = false;

    /// Метод перезапускает генерацию случайных чисел
    public void Restart()
    {
        Debug.Log("NumberParity.Restart()");
        // Запускаем игровую сессию
        _isGameActive = true;
        // Сбрасываем счетчики
        _correctTracker?.Reset();
        _incorrectTracker?.Reset();
        // Генерируем первое число
        GenerateNumber();
    }

    /// Метод удаляет отображение заданного числа
    public void Clear()
    {
        Debug.Log("NumberParity.Clear()");
        // Завершаем игровую сессию
        _isGameActive = false;
        // Очищаем отображение числа
        _view?.Clear();
    }

    /// Метод обрабатывает нажатие кнопки «Четное»
    public void OnEvenButtonClick()
    {
        Debug.Log("NumberParity.OnEvenButtonClick()");
        // Обрабатываем ответ (четное - true)
        ProcessAnswer(true);
    }

    /// Метод обрабатывает нажатие кнопки «Нечетное»
    public void OnOddButtonClick()
    {
        Debug.Log("NumberParity.OnOddButtonClick()");
        // Обрабатываем ответ (нечетное - false)
        ProcessAnswer(false);
    }

    // Генерируем случайное число
    private void GenerateNumber()
    {
        _number = Random.Range(_lowerBound, _upperBound + 1);
        _view?.Display(_number);
    }

    // Обрабатываем ответ пользователя
    private void ProcessAnswer(bool isEven)
    {
        // Проверяем, активна ли игра
        if (!_isGameActive) return;

        // Проверяем правильность ответа
        bool isNumberEven = (_number % 2 == 0);
        if (isNumberEven == isEven)
        {
            _correctTracker?.Track();
        }
        else
        {
            _incorrectTracker?.Track();
        }

        // Генерируем следующее число
        GenerateNumber();
    }
}
