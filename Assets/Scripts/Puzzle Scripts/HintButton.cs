using UnityEngine;
using System.Collections;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    private Vector3 originalScale;
    private Coroutine scaleCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void OnHintPressed()
    {
        if (gameObject.activeInHierarchy)
        {
            if (scaleCoroutine != null)
                StopCoroutine(scaleCoroutine);
            scaleCoroutine = StartCoroutine(ScaleAnimation());
        }

        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);
    }

    private IEnumerator ScaleAnimation()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
        scaleCoroutine = null;
    }
}
