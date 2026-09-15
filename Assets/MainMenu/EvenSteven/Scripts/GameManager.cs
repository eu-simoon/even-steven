using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Поле со ссылкой на игровой объект с холстом меню
    [SerializeField] private GameObject _menuScreen;

    // Поле со ссылкой на игровой объект с холстом игры
    [SerializeField] private GameObject _playScreen;

    // Поле со ссылкой на компонент кнопка «Четное число»
    [SerializeField] private Button _evenNumberButton;

    // Поле со ссылкой на компонент кнопка «Нечетное число»
    [SerializeField] private Button _oddNumberButton;

    // Поле со ссылкой на компонент кнопка «Заново»
    [SerializeField] private Button _restartButton;

    // Поле со ссылкой на компонент, хранящий заданное число
    [SerializeField] private NumberParity _numberParity;

    // Поле со ссылкой на компонент таймер
    [SerializeField] private Timer _timer;

    /// Метод вызывается при запуске приложения
    private void Start()
    {
        // Переключаемся на экран меню
        SwitchToMenuScreen();
    }

    /// Метод вызывается по нажатию кнопки «Начать игру»
    public void OnGameStart()
    {
        // Переключаемся на экран игры
        SwitchToPlayScreen();
        // Включаем кнопки принятия ответов и выключаем кнопку «Заново»
        SwitchButtonsToPlayGameState();
        // Перезапускаем таймер и генерируем новое заданное число
        RestartTimerAndNumberParity();
    }

    /// Метод вызывается, когда таймер завершил отсчёт времени
    public void OnGameEnd()
    {
        // Останавливаем таймер и удаляем отображение заданного числа
        StopTimerAndClearNumberParity();
        // Выключаем кнопки принятия ответов и включаем кнопку «Заново»
        SwitchButtonsToEndGameState();
    }

    public void OnGameRestart()
    {
        // Перезапускаем таймер и генератор заданных чисел
        RestartTimerAndNumberParity();
        // Включаем кнопки принятия ответов и выключаем кнопку «Заново»
        SwitchButtonsToPlayGameState();
    }

    /// Метод вызывается по нажатию кнопки «Главное меню»
    public void OnMainMenu()
    {
        // Останавливаем таймер и очищаем отображение заданного числа
        StopTimerAndClearNumberParity();
        // Переключаемся на экран меню
        SwitchToMenuScreen();
    }

    /// Метод переключает на экран главного меню
    private void SwitchToMenuScreen()
    {
        // Включаем игровой объект с холстом меню
        _menuScreen.SetActive(true);
        // Выключаем игровой объект с холстом игры
        _playScreen.SetActive(false);
    }

    /// Метод переключает на экран игры
    private void SwitchToPlayScreen()
    {
        // Выключаем игровой объект с холстом меню
        _menuScreen.SetActive(false);
        // Включаем игровой объект с холстом игры
        _playScreen.SetActive(true);
    }

    /// Метод перезапускает таймер и генератор заданных чисел
    private void RestartTimerAndNumberParity()
    {
        // Перезапускаем таймер
        _timer.Restart();
        // Перезапускаем генератор заданных чисел
        _numberParity.Restart();
    }

    /// Метод останавливает таймер и очищает генератор заданных чисел
    private void StopTimerAndClearNumberParity()
    {
        // Останавливаем таймер
        _timer.Stop();
        // Очищаем генератор заданных чисел
        _numberParity.Clear();
    }

    private void SwitchButtonsToPlayGameState()
    {
        // Выключаем интерактивность кнопок «Четное» и «Нечетное»
        _evenNumberButton.interactable = true;
        _oddNumberButton.interactable = true;
        // Выключаем интерактивность кнопки «Рестарт»
        _restartButton.interactable = false;
    }

    private void SwitchButtonsToEndGameState()
    {
        // Включаем интерактивность кнопок «Четное» и «Нечетное»
        _evenNumberButton.interactable = false;
        _oddNumberButton.interactable = false;
        // Включаем интерактивность кнопки «Рестарт»
        _restartButton.interactable = true;
    }
}