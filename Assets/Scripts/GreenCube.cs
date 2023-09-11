using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using Cysharp.Threading.Tasks;

//playerにアタッチする
public class GreenCube : MonoBehaviour
{
    PlayerScript _playerScript;
    public GameObject cameraPoint;
    public Text _eventText;
    Animator animator;
    IDisposable updateSubscription;
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GetComponent<PlayerScript>();
       animator = GetComponent<Animator>();    
    }
    
    public void GreenCubeAction()
    {
        int _randomNumber = UnityEngine.Random.Range(1,3);
        Vector3 moveDistance = new Vector3(_randomNumber, 0, 0);
        _eventText.text = _randomNumber.ToString() + "マス進む";
        var targetPos = transform.position + moveDistance;
        if(targetPos.x > 29)
        {
            targetPos.x = 29;
        }
        transform.LookAt(targetPos);
        
        updateSubscription = this.UpdateAsObservable()
                                 .Subscribe(async _ => 
                                 {
                                      Vector3 dir = (targetPos - transform.position).normalized;
                                      transform.position += dir * speed * Time.deltaTime;
                                      animator.SetBool("Running", true);
                                      
                                      if((targetPos - transform.position).magnitude < 0.1f)
                                      {
                                         transform.position = targetPos;
                                         transform.LookAt(cameraPoint.transform.position);
                                         animator.SetBool("Running", false);
                                         updateSubscription.Dispose();
                                         await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                                         _playerScript.GetAction(transform.position);
                                      }
                                 });
    }
}
