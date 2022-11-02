using UnityEngine;
using System.Collections.Generic;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public Vector3 BallSize { get; set; }

    protected GameObject _particleSfx { get; set; }

    public static float _zPosition = -11.21f;

    public Ball() { }
    public Ball(Color ballColor) => this.BallColor = ballColor;
    public Ball(Vector3 ballSize) => this.BallSize = ballSize;

    public void InitNewBall(GameObject _ballObejct, float x, float y, int xPos, int yPos, GameObject _electricSfx) 
        => CreateNewBallModel(out _ballObejct, x, y, xPos, yPos, _electricSfx);

    protected virtual void CreateNewBallModel(out GameObject _ballObejct, float x, float y, int xPos, int yPos, GameObject _electricSfx)
    {
        _ballObejct = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject ballModelChild = new GameObject();

        ballModelChild.transform.SetParent(_ballObejct.transform);
        ballModelChild.gameObject.SetActive(false);
        ballModelChild.AddComponent<BallGroupsCreating>();
        ballModelChild.AddComponent<SphereCollider>();
        
        SphereCollider spc1 = _ballObejct.GetComponent<SphereCollider>();
        SphereCollider spc2 = ballModelChild.GetComponent<SphereCollider>();

        spc1.radius = 0.50f;
        spc1.isTrigger = true;
        spc2.radius = 2.0f;
        spc2.isTrigger = true;

        _ballObejct.transform.localScale = BallSize;
        _ballObejct.transform.position = new Vector3(x + BallSize.x * xPos, y + BallSize.y * yPos, _zPosition);

        _ballObejct.AddComponent<BallDetection>();
        _ballObejct.AddComponent<Rigidbody>().isKinematic = true;
        
        var ballModelRenderer = _ballObejct.GetComponent<Renderer>();
        ballModelRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        int index = Random.Range(0, 5);

        List<Color> colors = new List<Color>
        {
            Color.black,
            Color.white,
            Color.green, 
            Color.red,
            Color.cyan,
            Color.blue,
            Color.gray
        };

        return colors[index];
    }
}

public sealed class UserBall : Ball
{
    public delegate GameObject OnGenerateNewUserBall();
    public OnGenerateNewUserBall _onGenerateNewUserBall;

    private GameObject _userBall;

    public UserBall() => _onGenerateNewUserBall = () => GenerateNewUserBall();
    
    private GameObject GenerateNewUserBall()
    {
        CreateNewBallModel(out _userBall, 0f, 2.66f, 1, 1, _particleSfx);
        return _userBall;
    }
    
    protected override void CreateNewBallModel(out GameObject _ballObejct, float x, float y, int xPos, int yPos, GameObject _electricSfx)
    {
        base.CreateNewBallModel(out _ballObejct, x, y, xPos, yPos, _electricSfx);

        _ballObejct.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        _ballObejct.GetComponent<SphereCollider>().isTrigger = false;
    }
}
