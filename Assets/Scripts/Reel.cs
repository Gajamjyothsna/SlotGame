using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Reel : MonoBehaviour
{
    public Image[] reelImages; // The images in the reel
    public string[] slotValues; // The available values for the slots
    public float spinDuration = 2.0f; // Duration for which the reel spins
    public float updateInterval = 0.1f; // Interval between value updates
    public GameObject reelAnimationObject;
    public GameObject reelObject;
    public float reelSpeedMultiplier = 10.0f; // Speed multiplier for the animation
    private Animator reelAnimator;
    private bool isSpinning = false;

    public Reel(Image[] images, string[] values, GameObject animationObject, GameObject reelObj, float duration, float interval, float speedMultiplier)
    {
        reelImages = images;
        slotValues = values;
        reelAnimationObject = animationObject;
        reelObject = reelObj;
        spinDuration = duration;
        updateInterval = interval;
        reelSpeedMultiplier = speedMultiplier;
        reelAnimator = reelObject.GetComponent<Animator>();

        // Optionally initialize the reel with random values
        foreach (var image in reelImages)
        {
            SetRandomValue(image);
        }
    }
    public void StartSpin(MonoBehaviour coroutineRunner)
    {
        reelAnimationObject.SetActive(true);
        if (!isSpinning)
        {
            coroutineRunner.StartCoroutine(SpinReel());
        }
    }


    private IEnumerator SpinReel()
    {
        isSpinning = true;
        reelAnimator.SetFloat("SpeedMultiplier", reelSpeedMultiplier);
        reelAnimator.SetTrigger("playReel");
        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            foreach (var image in reelImages)
            {
                SetRandomValue(image);
            }

            elapsedTime += updateInterval;
            yield return new WaitForSeconds(updateInterval);
        }

        // Show final content after spinning
        ShowFinalContent();
        isSpinning = false;
    }

    private void ShowFinalContent()
    {
        foreach (var image in reelImages)
        {
            SetRandomValue(image); // Replace this with your logic for final content
        }
        reelAnimationObject.SetActive(false);
    }

    private void SetRandomValue(Image image)
    {
        TextMeshProUGUI text = image.GetComponentInChildren<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = slotValues[Random.Range(0, slotValues.Length)];
        }
    }
}
