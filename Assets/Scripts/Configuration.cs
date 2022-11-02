using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsCollection;
    [SerializeField] private int _collectionLength;
    [SerializeField] private int _collectionDeep;

    private GameObject _electricSfxPrefab;

    private void Start()
    {
        _ballsCollection = new List<Ball>();

        GameObject _ballObejct = new GameObject();
        Vector2 firstBallPosition = new Vector2(-3.41f, 6.0f);

        for (int i = 1; i < _collectionLength; i++)
        {
            for (int j = 1; j < _collectionDeep; j++)
            {
                Ball _ball = new Ball(new Vector3(0.4f, 0.4f, 0.4f));
                _ball.InitNewBall(_ballObejct, firstBallPosition.x, firstBallPosition.y, i, j, _electricSfxPrefab);

                _ballsCollection.Add(_ball);
            }
        }
    }
}
