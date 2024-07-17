using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotReel : MonoBehaviour
{
    public Image[] reelImages; // The images in the reel
    public int[] slotValues; // The available values for the slots
    public float spinDuration = 2.0f; // Duration for which the reel spins
    public float updateInterval = 0.1f; // Interval between value updates

    private bool isSpinning = false;

    void Start()
    {
        // Optionally initialize the reel with random values
        foreach (var image in reelImages)
        {
            SetRandomValue(image);
        }
    }

    public void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinReel());
        }
    }

    private IEnumerator SpinReel()
    {
        Debug.Log("SpinReel");
        isSpinning = true;
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
    }

    private void SetRandomValue(Image image)
    {
        Text text = image.GetComponentInChildren<Text>();
        if (text != null)
        {
            int randomValue = slotValues[Random.Range(0, slotValues.Length)];
            text.text = randomValue.ToString();
        }
    }
}
