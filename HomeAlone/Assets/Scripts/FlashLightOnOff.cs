using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightOnOff : MonoBehaviour {

    public Light light;

    [Header("Battery")]
    [Space(7f)]
    public Slider batteryLevel;
    private float batteryLeft;
    public float initialBattery = 100;
    public float blinkingThreshold;
    public float timer;
    private float timeLeft;
    GameObject box;

    [Header("Blinking")]
    [Space(7f)]
    public float minWait;
    public float maxWait;
    public float minIntensity;
    public float maxIntensity;
    private bool canBlink = false;

    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        box = GameObject.Find("Flashlight");
        batteryLeft = initialBattery;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            light.enabled = !light.enabled;
        }

        if(light.enabled)
        {

            if (timeLeft <= 0)
            {
                batteryLeft--;
                timeLeft = timer;
            }

            else timeLeft -= Time.deltaTime;

            box.GetComponent<BoxCollider>().enabled = true;

            if (batteryLeft < blinkingThreshold)
            {
                StartCoroutine(Blink());
            }

            else canBlink = false;

            if (batteryLeft < 0)
                batteryLeft = 0;
        }

        else
        {
            if (timeLeft <= 0)
            {
                batteryLeft++;
                timeLeft = timer;
            }

            else timeLeft -= Time.deltaTime;

            box.GetComponent<BoxCollider>().enabled = false;

            if (batteryLeft > initialBattery)
                batteryLeft = initialBattery;
        }

        batteryLevel.value = batteryLeft;
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        light.intensity = Random.Range(minIntensity, maxIntensity);

        if(batteryLeft > blinkingThreshold)
        {
            light.intensity = maxIntensity;
            yield break;
        }
    }
}
