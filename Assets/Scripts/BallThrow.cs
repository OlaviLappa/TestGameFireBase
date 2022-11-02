using System.Collections;
using UnityEngine;
using static UserBall;

public class BallThrow
{
    private GameObject _currentBall;
    
    public void NextThrow(OnGenerateNewUserBall onGenerateNewUserBall)
    {
        if(_currentBall == null)
        {
            _currentBall = onGenerateNewUserBall();
            _currentBall.AddComponent<ObjectManipulation>();
        }
    }
}
