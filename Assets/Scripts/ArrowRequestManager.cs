using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject _catchEffectPrefab;

    [SerializeField]
    private RectTransform _effectParent;

    [SerializeField]
    private Image _damageImage;

    private void Start()
    {
        InputController.Instance.onInput += OnInput;
        LevelManagament.Instance.onPauseStateChanged += OnLevelComplited;
        _damageImage.enabled = false;

        CreateDelay(1);
    }

    private void OnLevelComplited(bool isPaused)
    {
        if (isPaused)
        {
            enabled = false;
            CancelInvoke();
        }
        else
        {
            CreateDelay(2);
        }
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
        CreateCatchEffect();
        ScoreManager.Instance.AddScore(1);
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        _arrowCatchTimeController.RemoveCurrentCatchTime();
    }

    private void CreateCatchEffect()
    {
        GameObject effect = Instantiate(_catchEffectPrefab, _effectParent);

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _effectParent,
            _currentArrowRequest.transform.position,
            Camera.main,
            out pos
        );
        RectTransform effectRectTransform = (RectTransform)effect.transform;
        effectRectTransform.anchoredPosition = pos;
    }

    private void OnArrowTimeEnded()
    {
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        OnPlayerLosesCatch();
    }

    private void OnPlayerLosesCatch()
    {
        StartCoroutine(LifeTakenEffect());
        CreateDelay(2);
        ArrowsRequestCreator.Instance.DeleteArrow(_currentArrowRequest.arrowCode);
        _arrowCatchTimeController.RemoveCurrentCatchTime();
        LifesSystem.Instance.TakeHealth();
    }

    private IEnumerator LifeTakenEffect()
    {
        _damageImage.enabled = true;

        Color color = _damageImage.color;
        float lifeTime = 1f;
        for (float t = 0; t < lifeTime; t += Time.deltaTime)
        {
            float process = t / lifeTime;
            color.a = Mathf.Sin(Mathf.PI * process);
            _damageImage.color = color;
            yield return null;
        }

        _damageImage.enabled = false;
    }
}
