using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class MoneyManager : MonoBehaviour
{
    public int _moneyNumber;
    public Text _moneyNumberText;

    // Start is called before the first frame update
    void Start()
    {
        _moneyNumber = 0;
        this.UpdateAsObservable()
            .Subscribe(_ => 
            {
                _moneyNumberText.text = _moneyNumber.ToString() + "円";
            })
            .AddTo(this);
    }

    
}
