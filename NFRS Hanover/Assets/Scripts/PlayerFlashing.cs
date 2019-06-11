using UnityEngine;

public class PlayerFlashing : MonoBehaviour
{
    [SerializeField] private float flashingTime;
    private float currentTime;

    private bool isFlashing = false;
    private bool isRed = false;

    void Update()
    {
        if (isFlashing)
        {
            currentTime += Time.unscaledDeltaTime;
            if (currentTime >= flashingTime)
            {
                if (isRed)
                {
                    var color = this.GetComponent<SpriteRenderer>().color;
                    color.g = 1f;
                    color.b = 1f;
                    this.GetComponent<SpriteRenderer>().color = color;
                    isRed = false;
                }
                else
                {
                    var color = this.GetComponent<SpriteRenderer>().color;
                    color.g = .4f;
                    color.b = .4f;
                    this.GetComponent<SpriteRenderer>().color = color;
                    isRed = true;
                }
                currentTime = 0f;
            }
        }
    }

    public void StartFlashing()
    {
        isFlashing = true;
    }

    public void StopFlashing()
    {
        isFlashing = false;
        var color = this.GetComponent<SpriteRenderer>().color;
        color.g = 1f;
        color.b = 1f;
        this.GetComponent<SpriteRenderer>().color = color;
    }
}