using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using Cysharp.Threading.Tasks;

//playerにアタッチする
public class YellowCube : MonoBehaviour
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
    
    public void YellowCubeAction()
    {
        int _randomNumber = UnityEngine.Random.Range(-3,-1);
        Vector3 moveDistance = new Vector3(_randomNumber, 0, 0);
        int _randomNumber2 = Mathf.Abs(_randomNumber);
        _eventText.text = _randomNumber2.ToString() + "マス戻る";
        var targetPos = transform.position + moveDistance;
        if(targetPos.x < 1)
        {
            targetPos.x = 1;
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
