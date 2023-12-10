using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthProgressBar : MonoBehaviour
{
    [SerializeField] private Image FillImg;
    [SerializeField] private TextMeshProUGUI ValueText;

    private float currentValue = 100;
    private float value = 100;

    public iTween.EaseType Ease = iTween.EaseType.easeOutSine;

    public bool isAnimating = false;

    public float Value
    {
        set
        {
            this.value = Mathf.Min(100f, value);

            iTween.Stop(gameObject);

            iTween.ValueTo(gameObject, iTween.Hash("from", currentValue, "to", this.value, "onupdate",
                "OnUpdateValue",
                "easeType",
                Ease, "time", 0.1f));
        }
    }

    private void OnUpdateValue(float value)
    {
        currentValue = value;

        FillImg.fillAmount = value / 100f;
        ValueText.text = (int)value + "";
    }
}