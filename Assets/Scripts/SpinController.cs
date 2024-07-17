using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinController : MonoBehaviour
{
    public Reel reelOne;
    public Reel reelTwo;

    public Image[] reelOneImages;
    public Image[] reelTwoImages;
    public string[] reelOneSlotValues;
    public string[] reelTwoSlotValues;

    public GameObject reelOneAnimationObject;
    public GameObject reelTwoAnimationObject;

    public GameObject reelOneObject;
    public GameObject reelTwoObject;

    public float spinDuration = 2.0f; // Duration for which the reel spins
    public float updateInterval = 0.1f; // Interval between value updates
    public float reelSpeedMultiplier = 10.0f; // Speed multiplier for the animation

    void Start()
    {
        reelOne = new Reel(reelOneImages, reelOneSlotValues, reelOneAnimationObject, reelOneObject, spinDuration, updateInterval, reelSpeedMultiplier);
        reelTwo = new Reel(reelTwoImages, reelTwoSlotValues, reelTwoAnimationObject, reelTwoObject, spinDuration, updateInterval, reelSpeedMultiplier);
    }

    public void StartSpin()
    {
        reelOne.StartSpin(this);
        reelTwo.StartSpin(this);
    }
}
