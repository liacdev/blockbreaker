using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // Cached references
    GameSession theGameSession;
    BallPosition theBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBallPosition = FindObjectOfType<BallPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBallPosition.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
