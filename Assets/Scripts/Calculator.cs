using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{

    public TextMeshProUGUI inputText;

    private float _result;
    private float _input;
    private float _input2;
    private string _operation;
    private bool operationGoingOn = false;

    void Start()
    {
        
    }

    public void ClickNumber(int val)
    {
        if (!operationGoingOn)
        {
            if (_input == 0)
            {
                _input = val;
                inputText.text = $"{val}";
            }
            else
            {
                if (_input > 0 && _input < 10)
                {
                    if (val != 0)
                        _input = _input*10 + val;
                    else
                        _input = _input * 10;
                    inputText.text = _input.ToString();
                }
                else
                {
                    if (_input > 9 && _input < 100)
                    {
                        if (val != 0)
                            _input = _input*10 + val;
                        else
                            _input = _input * 10;
                        inputText.text = _input.ToString();
                    }
                    else
                    {
                        if (_input > 99 && _input < 1000)
                        {
                            if (val != 0)
                                _input = _input * 10 + val;
                            else
                                _input = _input * 10;
                            inputText.text = _input.ToString();
                        }
                            
                    }
                }
            }
        }
        else
        {
            if (_input2 == 0)
            {
                _input2 = val;
                inputText.text = $"{val}";
            }
            else
            {
                if (_input2 > 0 && _input2 < 10)
                {
                    if (val != 0)
                        _input2 = _input2*10 + val;
                    else
                        _input2 = _input2 * 10;
                    inputText.text = _input2.ToString();
                }
                else
                {
                    if (_input2 > 9 && _input2 < 100)
                    {
                        if (val != 0)
                            _input2 = _input2 * 10 + val;
                        else
                            _input2 = _input2 * 10;
                        inputText.text = _input2.ToString();
                    }
                    else
                    {
                        if (_input2 > 99 && _input2 < 1000)
                        {
                            if (val != 0)
                                _input2 = _input2 * 10 + val;
                            else
                                _input2 = _input2 * 10;
                            inputText.text = _input2.ToString();
                        }

                    }
                }
            }
        }
    }


    public void ClickOperation(string val)
    {
        _operation = val;
        operationGoingOn = true;

    }

    public void ClickEqual()
    {
        if ( _input != 0 && _input2 != 0 && !string.IsNullOrEmpty(_operation))
        {
            switch (_operation)
            {
                case "+":
                    _result = _input + _input2;
                    break;
                case "-":
                    _result = _input - _input2;
                    break;
                case "*":
                    _result = _input * _input2;
                    break;
                case "%":
                    _result = _input / _input2;
                    break;
            }

            inputText.SetText(_result.ToString());
            ClearInput();
        }

    }

    private void ClearInput()
    {
        _input = _result;
        _input2 = 0;
        operationGoingOn = false;
    }

    public void ClickC()
    {
        _input = 0;
        _input2 = 0;
        operationGoingOn = false;
        inputText.text = "0";
    }

}
