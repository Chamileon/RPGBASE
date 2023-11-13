using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour, IBasicInfo
{
    [Header("Basic Info")]
    [SerializeField] private string _name = "";
    [SerializeField] private string _description =  "";
    public string NAME => _name;
    public string DESCRIPTION => _description;
    [Header("Pages Of Event")]
    [Range(0,10)]public int pageNumber;
    private int MaxPagesNumber() 
    { 
        if (_pages != null) { return _pages.Length; }
        else { return 0; }
    }
    [SerializeField] private GameEventPage[] _pages;
    public GameEventPage ActualPage()
    {
        var page = _pages[pageNumber -1];
        return page;
    }
    public void ActualizeActualPage() 
    {
        var page = ActualPage();
        if (page != null) 
        {
            if(page.Condition() != null) 
            {
                Debug.Log(page.Condition().NAME);
                Debug.Log(page.Condition().DESCRIPTION);
                Debug.Log(page.Condition().IsActive() + " is the active status.");
                if (page.Condition().IsActive() == true)
                {
                    if (pageNumber < MaxPagesNumber())
                    {
                        OnPageChange?.Invoke();
                        pageNumber++;
                    }
                }
            }
        } 
    }
    public void MoveRandom(EventMoveType moveType) 
    {
        if(moveType == EventMoveType.Random) 
        {
            if (!_isMoving && PerlinSwitch()) StartCoroutine(Walk(Direction(direction)));
        }
    }
    public Direction direction;
    [SerializeField] [Range(0.1f, 1f)] private float _umbralMove;
    [SerializeField] [Range(0.1f, 1f)] private float _umbralDirection;
    public bool canMove;
    [SerializeField] private bool _isMoving;
    [SerializeField] private float _moveDelay;
    public Vector2 Direction(Direction direct) 
    {
        switch (direct) 
        {
            case global::Direction.Zero: return Vector2.zero;
            case global::Direction.Left: return new Vector2(-1, 0);
            case global::Direction.Right: return new Vector2(1, 0);
            case global::Direction.Down: return new Vector2(0, -1);
            case global::Direction.Up: return new Vector2(0, 1);
                default: return new Vector2(0, 0);
        }
    }
    public IEnumerator Wait() 
    {
        _isMoving = true;
        canMove = false;
        float timer = 0f;
        while(timer < _moveDelay) 
        {
            yield return null;
            timer += Time.deltaTime;
        }
        _isMoving = false;
        canMove = true;
    }
    public IEnumerator Walk(Vector2 direct) 
    {
        if (CanSwitchDirection()) ChangeDirection();
        float timeElapsed = 0;
        Vector2 posInit = transform.position;
        Vector2 posFinal = posInit + Direction(direction);
        while (timeElapsed < _moveDelay)
        {            
            _isMoving = true;
            var posX = Mathf.Lerp(posInit.x, posFinal.x, timeElapsed / _moveDelay);
            var posY = Mathf.Lerp(posInit.y,posFinal.y, timeElapsed / _moveDelay);
            transform.position = new Vector2(posX, posY);
            timeElapsed += Time.deltaTime;
            yield return null;
            
        }
        transform.position = posFinal;
        _isMoving = false;
    }
    public bool PerlinSwitch() 
    {
        float i = Mathf.PerlinNoise(transform.position.x, transform.position.y) * 100 * Time.deltaTime * 3 * .5f;
        //Debug.Log(i + " is the switch umbral.");
        if(i >= _umbralMove) return true;
        return false;
    }
    bool CanSwitchDirection() 
    {
        float i = Mathf.PerlinNoise(transform.position.x, transform.position.y) * 100 * Time.deltaTime *3 * .5f;
        Debug.Log(i + " is the direction umbral.");

        if (i >= _umbralDirection) return true;
        return false;
    }
    public void ChangeDirection() 
    {
        int random = Random.Range(0,8);
        switch (random) 
        {

            case 1: direction = global::Direction.Left; break;
            case 2: direction = global::Direction.Right; break;
            case 3: direction = global::Direction.Up; break;
            case 4: direction = global::Direction.Down; break;
            default: direction = global::Direction.Zero; break;
        }
    }
    public void MoveFixed() 
    {
        if (!_isMoving) StartCoroutine(Wait());
    }

    public delegate void OnPageChangeDelegate();

    public virtual event OnPageChangeDelegate OnPageChange;
    private void Start()
    {
        
    }
    public void Update()
    {
        ActualizeActualPage();
        if (!_isMoving) 
        {
            if (PerlinSwitch())
            {
                MoveRandom(ActualPage().moveType);
            }
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        ActualizePages();
        //ActualizeTransform();
    }
    private void ActualizeTransform() 
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        pos.x = Mathf.FloorToInt(pos.x) + .5f;
        pos.y = Mathf.FloorToInt(pos.y) + .5f;

        transform.position = pos;
        Debug.Log(pos);
    }
    private void ActualizePages()
    {
        if (_pages != null)
        {
            
            pageNumber = Mathf.Clamp(pageNumber, 1, MaxPagesNumber());
            if(pageNumber < 1) pageNumber = 1;
            if (_pages.Length == 0) pageNumber = 0;
        }
        else
        {
            pageNumber = -1;
        }
    }
#endif
}
