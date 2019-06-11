using Hanover.CommandPattern;
using Hanover.Physics;
using UnityEngine;
using UnityEngine.UI;

public class GravityToggleCommand : MonoBehaviour, IPhysicsCommand
{
    private ScreenShake c_Shake;

    [SerializeField]
    private float TotalDuration = 3.0f, RechargeTime = 3.0f;
    [SerializeField]
    private GameObject Powerbar;
    private Slider PowerbarSlider;

    private float Timer = 0.0f;
    private bool Enabled = true, Active = false;
    private PlayerPhysics Physics = null;

    private void Start()
    {
        PowerbarSlider = Powerbar.GetComponent<Slider>();
        c_Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

    public void Execute(GameObject player, Vector2 axes, PlayerPhysics physics)
    {
        if (!Enabled && !Active)
        {
            return;
        }

        if (Physics == null)
        {
            Physics = physics;
            TotalDuration = Physics.AntigravityDuration;
        }


        if (Physics.GravityEnabled)
        {
            Timer = 0.0f;
            Physics.GravityEnabled = false;
            Active = true;

            Powerbar.SetActive(true);
            PowerbarSlider.value = 1;
            c_Shake.SmallShake(0.1f);
        }
        else
        {
            Physics.GravityEnabled = true;
            Active = false;
            Enabled = false;
            c_Shake.SmallShake(0.1f);
        }
    }

    void Update()
    {
        if (Active)
        {
            Timer += Time.deltaTime;
            PowerbarSlider.value -= Time.deltaTime / TotalDuration;

            if (Timer >= TotalDuration)
            {
                Timer = 0f;
                Active = false;
                Enabled = false;
                Physics.GravityEnabled = true;
                c_Shake.SmallShake(0.1f);
            }
        }
        else if (!Enabled)
        {
            PowerbarSlider.value += Time.deltaTime / TotalDuration;

            if (PowerbarSlider.value >= 1)
            {
                PowerbarSlider.value = 1;
                Powerbar.SetActive(false);
                Enabled = true;
            }
        }
    }
}
