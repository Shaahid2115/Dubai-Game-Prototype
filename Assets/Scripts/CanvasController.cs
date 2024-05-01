using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Needed for EventTrigger

public class CanvasController : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public VideoPlayer videoPlayer;
    public Image skipImage; // Public variable for the skip image

    void Start()
    {
        // Initially, show Canvas1 and hide Canvas2
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);

        // Register a callback for when the video finishes playing
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        // Set up the EventTrigger for the skip image
        if (skipImage != null)
        {
            EventTrigger eventTrigger = skipImage.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick,
                callback = new EventTrigger.TriggerEvent()
            };
            entry.callback.AddListener((data) => { OnSkipImageClicked(); });
            eventTrigger.triggers.Add(entry);
        }
    }

    public void OnSkipImageClicked()
    {
        // If the skip image is clicked, hide Canvas1 and show Canvas2
        SwitchToCanvas2();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // When the video ends, hide Canvas1 and show Canvas2
        SwitchToCanvas2();
    }

    void SwitchToCanvas2()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }
}
