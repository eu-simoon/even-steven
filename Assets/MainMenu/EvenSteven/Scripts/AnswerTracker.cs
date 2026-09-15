using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTracker : MonoBehaviour
{
    // Поле со ссылкой на компонент отображения количества ответов
    [SerializeField] private AnswerTrackerView _view;

    // Поле с текущим значением количества ответов
    private int _counter = 0;

    /// Метод сбрасывает счётчик ответов до начального состояния
    public void Reset()
    {
        // Сбрасываем счетчик в ноль
        _counter = 0;
        // Обновляем отображение
        _view?.Display(_counter);
    }

    /// Метод увеличивает значение счётчика ответов на единицу
    public void Track()
    {
        // Увеличиваем счетчик на 1
        _counter++;
        // Обновляем отображение
        _view?.Display(_counter);
    }

    // ДОПОЛНИТЕЛЬНО: Метод для получения текущего значения (для NumberParity)
    public int GetCount()
    {
        return _counter;
    }
}
