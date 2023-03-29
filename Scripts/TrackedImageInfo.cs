using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageInfo : MonoBehaviour {

    [SerializeField]
    private GameObject prefabOnTrack;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f,0.1f,0.1f);

    [SerializeField]
    XRReferenceImageLibrary xrReferenceImageLibrary;
    
    private ARTrackedImageManager trackImageManager;

    void Start()
    {
        trackImageManager = gameObject.AddComponent<ARTrackedImageManager>();
        trackImageManager.referenceLibrary = trackImageManager.CreateRuntimeLibrary(xrReferenceImageLibrary);
        trackImageManager.trackedImagePrefab = prefabOnTrack;

        trackImageManager.enabled = true;

        trackImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        
        ShowTrackerInfo();
    }

    public void ShowTrackerInfo()
    {
        var runtimeReferenceImageLibrary = trackImageManager.referenceLibrary as MutableRuntimeReferenceImageLibrary;

    }
    void OnDisable()
    {
        trackImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // Display the name of the tracked image in the canvas
            Debug.Log(trackedImage.referenceImage.name) ;
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // Display the name of the tracked image in the canvas
            Debug.Log(trackedImage.referenceImage.name) ;
            
        }
    }
}