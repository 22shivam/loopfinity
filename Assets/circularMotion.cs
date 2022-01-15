using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circularMotion : MonoBehaviour
{
    // type of circle object
    static float INITIAL_SPEED = 5f;
    public float RotateSpeed = INITIAL_SPEED;
    public ScoreManager ScoreManager;
    public float Radius = 2.3f;
    public RetryButton retryButton;
    private bool stop = false;
    private Vector2 _centre;
    private float _angle;
    void Start()
    {
        _centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            _angle += RotateSpeed * Time.deltaTime;
 
            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
            increaseRotateSpeed();
        }


    }

    public void stopCircle()
    {
        stop = true;
        retryButton.showButton();
    }

    public void startCircle()
    {
        stop = false;
        retryButton.hideButton();
        RotateSpeed = INITIAL_SPEED;
    }

    public void increaseRotateSpeed()
    {
        RotateSpeed = INITIAL_SPEED + ScoreManager.getScore() / 15;
        
    }

    public bool getStop()
    {
        return stop;
    }
    
}
