using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class CameraScript : MonoBehaviour
{
    public GameObject _player;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
       pos = transform.position - _player.transform.position;

       this.UpdateAsObservable()
           .Subscribe(_ => 
           {
             transform.position = pos + _player.transform.position;
           });
    }

   

    
}
