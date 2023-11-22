using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TextMeshProUGUI _persentText;

    private void Awake()
    {
        StartCoroutine(ShowProcess());
    }

    private IEnumerator ShowProcess()
    {
        // just for some entertainment
#if UNITY_EDITOR
        int testProcess = 0;
        for (float t = 0; t < 4; t += Time.deltaTime)
        {
            testProcess += Random.Range(0, 25);
            testProcess = Mathf.Clamp(testProcess, 0, 100);
            _persentText.text = testProcess.ToString();
            _slider.value = testProcess / 100f;

            if (testProcess == 100)
                break;

            yield return new WaitForSeconds(0.3f);
        }
        _persentText.text = 100.ToString() + "%";
        _slider.value = 1;

#endif

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(
            SceneController.NextSceneToLoadName
        );

        while (!loadingOperation.isDone)
        {
            float process = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            _persentText.text = (process * 100).ToString() + "%";
            _slider.value = process;

            yield return null;
        }
    }
}
