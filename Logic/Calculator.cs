using System;
using System.Globalization;

namespace Calculator2022.Logic;

public class Calculator
{
    //константы
    const int INPUT1 = 1;
    const int OPERATION = 2;
    const int INPUT2 = 3;
    const int RESULT = 4;
    const int ERROR = 5;

    //данные (приватные)
    string _screen; //экран калькулятора
    string _memory;
    string _op;
    int _state;

    //публичные методы
    //получить "содержимое" экрана
    public string Screen
    {
        get { return _screen; }
    }

    //конструктор
    public Calculator()
    {
        _screen = "0";
        _memory = "";
        _op = "";
        _state = INPUT1;
    }

    //"нажатие" на кнопку
    public void Press(string key)
    {
        try
        {
            switch (_state)
            {
                case INPUT1: ProcessInput1(key); break;
                case INPUT2: ProcessInput2(key); break;
                case OPERATION: ProcessOperation(key); break;
                case RESULT: ProcessResult(key); break;
                case ERROR: ProcessError(key); break;
            }
        }
        catch
        {
            _screen = "Error";
            _state = ERROR;
        }
    }
    void ProcessInput1(string key)
    {
        switch (GetKeyKind(key))
        {
            case KeyKind.Digit:
                AddDigit(key);
                _state = INPUT1;
                break;
            case KeyKind.Dot:
                AddDot();
                _state = INPUT1;
                break;
            case KeyKind.Sign:
                ChangeSign();
                _state = INPUT1;
                break;
            case KeyKind.Operation:
                _memory = _screen;
                _op = key;
                _state = OPERATION;
                break;
            case KeyKind.Result:
                _state = INPUT1;
                break;
            case KeyKind.Clear:
                Clear();
                _state = INPUT1;
                break;
            default:
                break;
        }
    }
    void ProcessInput2(string key)
    {
        switch (GetKeyKind(key))
        {
            case KeyKind.Digit:
                AddDigit(key);
                _state = INPUT2;
                break;
            case KeyKind.Dot:
                AddDot();
                _state = INPUT2;
                break;
            case KeyKind.Sign:
                ChangeSign();
                _state = INPUT2;
                break;
            case KeyKind.Operation:
                Calc();
                _op = key;
                _state = OPERATION;
                break;
            case KeyKind.Result:
                Calc();
                _state = RESULT;
                break;
            case KeyKind.Clear:
                Clear();
                _state = INPUT1;
                break;
            default:
                break;
        }
    }
    void ProcessOperation(string key)
    {
        switch (GetKeyKind(key))
        {
            case KeyKind.Digit:
                _screen = key;
                _state = INPUT2;
                break;
            case KeyKind.Dot:
                _screen = "0.";
                _state = INPUT2;
                break;
            case KeyKind.Sign:
                _state = OPERATION;
                break;
            case KeyKind.Operation:
                _op = key;
                _state = OPERATION;
                break;
            case KeyKind.Result:
                Calc();
                _state = RESULT;
                break;
            case KeyKind.Clear:
                Clear();
                _state = INPUT1;
                break;
            default:
                break;
        }
    }
    void ProcessResult(string key)
    {
        switch (GetKeyKind(key))
        {
            case KeyKind.Digit:
                _screen = key;
                _state = INPUT1;
                break;
            case KeyKind.Dot:
                _screen = "0.";
                _state = INPUT1;
                break;
            case KeyKind.Sign:
                ChangeSign();
                _state = RESULT;
                break;
            case KeyKind.Operation:
                _memory = _screen;
                _op = key;
                _state = OPERATION;
                break;
            case KeyKind.Result:
                Calc();
                _state = RESULT;
                break;
            case KeyKind.Clear:
                Clear();
                _state = INPUT1;
                break;
            default:
                break;
        }
    }
    void ProcessError(string key)
    {
        switch (GetKeyKind(key))
        {
            case KeyKind.Digit:
            case KeyKind.Dot:
            case KeyKind.Sign:
            case KeyKind.Operation:
            case KeyKind.Result:
                _state = ERROR;
                break;
            case KeyKind.Clear:
                Clear();
                _state = INPUT1;
                break;
            default:
                break;
        }
    }
    void Calc()
    {
        double arg1 = double.Parse(_memory, CultureInfo.InvariantCulture);
        double arg2 = double.Parse(_screen, CultureInfo.InvariantCulture);
        double res = 0;

        switch (_op)
        {
            case "+":
                res = arg1 + arg2;
                break;
            case "-":
                res = arg1 - arg2;
                break;
            case "*":
                res = arg1 * arg2;
                break;
            case "/":
                if (arg2 == 0)
                    throw new Exception();
                res = arg1 / arg2;
                break;
            default:
                throw new Exception();
        }

        _screen = res.ToString("0.###########", CultureInfo.InvariantCulture);
    }
    void AddDigit(string digit)
    {
        if (_screen == "0")
            _screen = digit;
        else
            _screen += digit;
    }
    void AddDot()
    {
        if (!_screen.Contains("."))
            _screen += ".";
    }
    void ChangeSign()
    {
        if (_screen == "0")
            return;
        if (_screen.StartsWith("-"))
            _screen = _screen.Substring(1);
        else
            _screen = "-" + _screen;
    }
    void Clear()
    {
        _screen = "0";
        _memory = "";
        _op = "";
    }
    KeyKind GetKeyKind(string key) =>
        key switch
        {
            "0" => KeyKind.Digit,
            "1" => KeyKind.Digit,
            "2" => KeyKind.Digit,
            "3" => KeyKind.Digit,
            "4" => KeyKind.Digit,
            "5" => KeyKind.Digit,
            "6" => KeyKind.Digit,
            "7" => KeyKind.Digit,
            "8" => KeyKind.Digit,
            "9" => KeyKind.Digit,
            "." => KeyKind.Dot,
            "-/+" => KeyKind.Sign,
            "+" => KeyKind.Operation,
            "-" => KeyKind.Operation,
            "*" => KeyKind.Operation,
            "/" => KeyKind.Operation,
            "=" => KeyKind.Result,
            "C" => KeyKind.Clear,
            _ => KeyKind.Undefined,
        };
}

enum KeyKind
{
    Digit,
    Dot,
    Sign,
    Operation,
    Result,
    Clear,
    Undefined,
}