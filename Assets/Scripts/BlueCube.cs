using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BlueCube : MonoBehaviour
{
    public MoneyManager _moneyManager;
    public Button _diceButton;
    public Text _eventText;
    Animator animator;
    List<int> _eventNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 1; i <= 10; i++)
        {
            _eventNumbers.Add(i);
        }
    }

    public void BlueCubeAction()
    {
        if (_eventNumbers.Count == 0)
        {
            Debug.Log("No more events available.");
            return;
        }

        animator.SetTrigger("Jump");
        _diceButton.gameObject.SetActive(true);

        int randomIndex = UnityEngine.Random.Range(0, _eventNumbers.Count);
        int selectedEventNumber = _eventNumbers[randomIndex];
        _eventNumbers.RemoveAt(randomIndex);

        ExecuteEvent(selectedEventNumber);
    }

    private void ExecuteEvent(int eventNumber)
    {
        switch (eventNumber)
        {
            case 1:
                Event1();
                break;
            case 2:
                Event2();
                break;
            case 3:
                Event3();
                break;
            case 4:
                Event4();
                break;
            case 5:
                Event5();
                break;
            case 6:
                Event6();
                break;
            case 7:
                Event7();
                break;
            case 8:
                Event8();
                break;
            case 9:
                Event9();
                break;
            case 10:
                Event10();
                break;
           
            default:
                Debug.Log("Invalid event number.");
                break;
        }
    }

    private void Event1()
    {
        _moneyManager._moneyNumber += 50000;
        _eventText.text = "バイトに励むため5万円もらう";
    }

    private void Event2()
    {
        _moneyManager._moneyNumber += 5000;
        _eventText.text = "誕生日に図書カードをもらうため5000円もらう";
    }

    private void Event3()
    {
        _moneyManager._moneyNumber += 10000;
        _eventText.text = "自分で作ったゲームが売れるため1万円もらう";
    }

    private void Event4()
    {
        _moneyManager._moneyNumber += 300000;
        _eventText.text = "宝くじにあたるため30万円もらう";
    }

    private void Event5()
    {
        _moneyManager._moneyNumber += 50000;
        _eventText.text = "パチンコでビギナーズラックをするため5万円もらう";
    }

    private void Event6()
    {
        _moneyManager._moneyNumber += 100000;
        _eventText.text = "株で短期的な利益を得るため10万円もらう";
    }

    private void Event7()
    {
        _moneyManager._moneyNumber += 500000;
        _eventText.text = "Youtubeがバズるため50万円もらう";
    }

    private void Event8()
    {
        _moneyManager._moneyNumber += 100000;
        _eventText.text = "競馬が当たるため10万円もらう";
    }

    private void Event9()
    {
        _moneyManager._moneyNumber += 500;
        _eventText.text = "500円玉を拾う";
    }

    private void Event10()
    {
        _moneyManager._moneyNumber += 1000000;
        _eventText.text = "ボーナスが入るため100万円もらう";
    }

    
}
