using UnityEngine;

// Code modified from
//  https://medium.com/@mattThousand/basic-2d-screen-shake-in-unity-9c27b56b516

public class ScreenShake : MonoBehaviour
{
    //Shake effect variables ////
    private Transform c_Transform;
    [SerializeField] private float shakeDuration = 0f;
    [SerializeField] private float shakeStrength = .5f;
    [SerializeField] private float dampening = 1.0f;
    Vector3 initPos;

    void Awake()
    {
        c_Transform = this.gameObject.transform;
    }

    void OnEnable()
    {
        initPos = c_Transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initPos + Random.insideUnitSphere * shakeStrength;

            shakeDuration -= Time.deltaTime * dampening;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initPos;
        }
    }

    public void Shake(float val)
    {
        Debug.Log("Shaking");
        shakeDuration = val;
    }
}