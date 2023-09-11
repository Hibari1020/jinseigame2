using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class GoalCube : MonoBehaviour
{
    public MoneyManager _moneyManager;
    public GameObject _userNameObject;
    public Button _diceButton;
    public Button _restartButton;
    public Button _returnButton;
    public Text _diceNumberText;
    public Text _gameClearText;
    public Text _moneyNumberText;
    public Text _moneyText;
    public Text _eventText;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        _restartButton.OnClickAsObservable()
                      .Subscribe(_ => 
                      {
                         SceneManager.LoadScene("SoloScene");
                      });
        
        _returnButton.OnClickAsObservable()
                     .Subscribe(_ => 
                     {
                        SceneManager.LoadScene("TitleScene");
                     });
    }

    public void GoalCubeAction()
    {
        _diceButton.gameObject.SetActive(false);
        _diceNumberText.gameObject.SetActive(false);
        _userNameObject.SetActive(false);
        _moneyNumberText.gameObject.SetActive(false);
        _moneyText.gameObject.SetActive(false);
        _eventText.gameObject.SetActive(false);
        _gameClearText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        _returnButton.gameObject.SetActive(true);
        animator.SetTrigger("Win");
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (_moneyManager._moneyNumber);

        
    }
}
