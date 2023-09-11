using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UserNameText : MonoBehaviour
{
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        var userNameText = GetComponent<TextMesh>();
        userNameText.text = UserName.userName;

        Vector3 pos = transform.position - _player.transform.position;

        this.UpdateAsObservable()
            .Subscribe(_ => 
            {
                transform.position = pos + _player.transform.position;
            });
    }

}
