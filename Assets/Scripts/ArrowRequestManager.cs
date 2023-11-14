using UnityEngine;

public class ArrowRequestManager : MonoBehaviour
{
    [SerializeField]
    private ArrowsRequestCreator _arrowsRequestCreator;

    [SerializeField]
    private ArrowCatchTimeController _arrowCatchTimeController;

    [SerializeField]
    private float _delay = 3f;

    // time when player should make the input
    [SerializeField]
    private float _catchTime = 1;
    private ArrowRequest _currentArrowRequest;
    private float _timer;

    private void Start()
    {
        InputController.Instance.onInput += OnInput;
        CreateDelay(1);
    }

    // create delay before starting to create catch time
    private void CreateDelay(float delayTime)
    {
        _timer = 0;
        enabled = false;
        float startDelay = 1f;
        Invoke(nameof(Enable), startDelay);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < _delay)
            return;

        enabled = false;
        _timer = 0;
        CreateCatchTime();
        CreateDelay(_delay);
    }

    private void Enable()
    {
        enabled = true;
    }

    private void OnInput(ArrowCode arrowCode)
    {
        if (_currentArrowRequest == null)
            return;

        if (arrowCode == _currentArrowRequest.arrowCode)
            OnPlayerCaughtRequest();
        else
            OnPlayerLosesCatch();
    }

    private void CreateCatchTime()
    {
        ArrowRequest[] arrows = _arrowsRequestCreator.GetArrows();

        if (arrows.Length == 0)
        {
            int newArrowsAmount = Random.Range(3, 4);
            _arrowsRequestCreator.CreateArrows(newArrowsAmount);
            return;
        }

        int number = Random.Range(0, arrows.Length);

        ArrowRequest arrow = arrows[number];
        _currentArrowRequest = arrow;
        _arrowCatchTimeController.CreateCatchTime(arrow, _catchTime, OnArrowTimeEnded);
    }

    private void OnPlayerCaughtRequest()
    {
        Debug.Log("add score");
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        _arrowCatchTimeController.RemoveCurrentCatchTime();
    }

    private void OnArrowTimeEnded()
    {
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        OnPlayerLosesCatch();
    }

    private void OnPlayerLosesCatch()
    {
        CreateDelay(2);
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        _arrowCatchTimeController.RemoveCurrentCatchTime();
        Debug.Log("lose score");
    }
}
