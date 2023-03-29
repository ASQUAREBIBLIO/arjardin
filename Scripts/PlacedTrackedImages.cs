using System;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

 [RequireComponent(typeof(ARTrackedImageManager))]

public class PlacedTrackedImages : MonoBehaviour {
    
    // private string[] plante = new string[V];
     // Reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;
     // List of prefabs to instantiate - these should be named the same
     // as their corresponding 2D images in the reference image library
    public GameObject[] ArPrefabs;

     // Keep dictionai y an ay
    private Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake() {
         // Cache a reference to the Tracked Image Manager component
         _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }
    void OnEnable() {
        // Attach event handler when tracked images change
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    void OnDisable(){
        // Remove event handler
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    
    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        // Loop through all new tracked images that have been detected
        
        foreach (var trackedImage in eventArgs.added){
            // StartCoroutine(GetPlantInfo());
        // Get the name of the reference image
            var imageName = trackedImage.referenceImage.name;

            // Now loop over the array of prefabs
            foreach (var curPrefab in ArPrefabs) {
                // Check whether this prefab matches the tracked image name, and that
                // the prefab hasn't already been created
                Console.Write(imageName);
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0) {
                    // Instantiate the prefab, parenting it to the ARTrackedImage
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    // Add the created prefab to our array
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        
        }
        // For all prefabs that have been created so far, set them active or not depending
        // on whether their corresponding image is currently being tracked
        foreach (var trackedImage in eventArgs.updated) {
            _instantiatedPrefabs[trackedImage.referenceImage.name]
                .SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        // If the AR subsystem has given up looking for a tracked image
        foreach (var trackedImage in eventArgs.removed) {
            // Destroy its prefab
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // Also remove the instance from our array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            // Or, simply set the prefab instance to inactive
            //_instantiatedPrefabs[trackedImage referenceImage.name.etActive (false);
        }       
    }
}

