using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// Класс отвечает за способ вывода информации о количестве верных или неверных ответов на экран

public class AnswerTrackerView : MonoBehaviour
{
    // Поле со ссылкой на компонент вывода текста на экран
    [SerializeField] private TMP_Text _outputText;

    /// Метод выводит значение счётчика на экран
    public void Display(int counter)
    {
        // Отображаем значение счетчика в текстовом поле
        _outputText.text = counter.ToString();
    }
}