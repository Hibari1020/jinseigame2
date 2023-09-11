using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CubeAction : MonoBehaviour
{
    public Dictionary<Vector3, Action> cubeActions = new Dictionary<Vector3, Action>();
    public GreenCube _greenCube; 
    public YellowCube _yellowCube;
    public RedCube _redCube;
    public BlueCube _blueCube;
    public GoalCube _goalCube;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 7; i++)
        {
           cubeActions.Add(new Vector3(1 + 4*(i - 1), 0, 0), () =>
           {
               Debug.Log("RedCubeのイベント");
               _redCube.RedCubeAction();
           });

           cubeActions.Add(new Vector3(2 + 4*(i - 1), 0, 0), () => 
           {
              Debug.Log("BlueCubeのイベント");
              _blueCube.BlueCubeAction();
           });

           cubeActions.Add(new Vector3(3 + 4*(i - 1), 0, 0), () =>
           {
               Debug.Log("GreenCubeのイベント");
               _greenCube.GreenCubeAction();

           });

           cubeActions.Add(new Vector3(4 + 4*(i - 1), 0, 0), () => 
           {
              Debug.Log("YellowCubeのイベント");
              _yellowCube.YellowCubeAction();
           });
        }

        cubeActions.Add(new Vector3(29, 0, 0), () => 
        {
            Debug.Log("GoalCubeのイベント");
            _goalCube.GoalCubeAction();
        });
      
    }

   
}
