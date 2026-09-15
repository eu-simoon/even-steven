using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// Класс отвечает за способ вывода заданного числа на экран
public class NumberParityView : MonoBehaviour
{
    // Поле со ссылкой на компонент вывода текста на экран
    [SerializeField] private TMP_Text _outputText;

    /// Метод очищает текстовое поле
    public void Clear()
    {
        // Очищаем текстовое поле
        _outputText.text = "";
    }

    /// Метод отображает значение числа на экране
    public void Display(int number)
    {
        // Отображаем число в текстовом поле
        _outputText.text = number.ToString();
    }
}