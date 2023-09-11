using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using System.Linq;

public class PlayerScript : MonoBehaviour
{
    public CubeAction _cubeAction;
    Animator animator;
    public Button _diceButton;
    public GameObject cameraPoint;
    public Text _diceText;
    private IDisposable updateSubscription;
    float speed = 3f;

    void Start()
    {
        _diceButton.onClick.AsObservable()
            .Subscribe(_ =>
            {
                DiceAction();
            })
            .AddTo(this);
    }

    public void DiceAction()
    {
        _diceButton.gameObject.SetActive(false);
        int _randomNumber = UnityEngine.Random.Range(1, 6);
        _diceText.text = _randomNumber.ToString();
        animator = GetComponent<Animator>();
        Vector3 moveDistance = new Vector3(_randomNumber, 0, 0);
        var targetPos = transform.position + moveDistance;
        if (targetPos.x > 29)
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

                if ((targetPos - transform.position).magnitude < 0.1f)
                {
                    transform.position = targetPos;
                    Debug.Log(transform.position);
                    transform.LookAt(cameraPoint.transform.position);
                    animator.SetBool("Running", false);
                    updateSubscription.Dispose();
                    await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                    GetAction(transform.position);
                }
            });
    }

    public void GetAction(Vector3 pos)
    {
        if (_cubeAction.cubeActions.TryGetValue(pos, out Action getAction))
        {
           getAction();
        }
        else
        {
            Debug.Log("Key is not found");
        }
    }

   
}
