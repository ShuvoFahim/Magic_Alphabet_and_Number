/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region Declered_Variable_For_Assets

    private GameObject A;
    private GameObject B;
    private GameObject C;
    private GameObject D;
    private GameObject E;
    private GameObject F;
    private GameObject G;
    private GameObject H;
    private GameObject I;
    private GameObject J;
    private GameObject K;
    private GameObject L;
    private GameObject M;
    private GameObject N;
    private GameObject O;
    private GameObject P;
    private GameObject Q;
    private GameObject R;
    private GameObject S;
    private GameObject T;
    private GameObject U;
    private GameObject V;
    private GameObject W;
    private GameObject X;
    private GameObject Y;
    private GameObject Z;

    private GameObject ZERO;
    private GameObject ONE;
    private GameObject TWO;
    private GameObject THREE;
    private GameObject FOUR;
    private GameObject FIVE;
    private GameObject SIX;
    private GameObject SEVEN;
    private GameObject EIGHT;
    private GameObject NINE;







    #endregion

    #region PROTECTED_MEMBER_VARIABLES



    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void FindingAssets() {

        A = GameObject.Find("A");
        B = GameObject.Find("B");
        C = GameObject.Find("C");
        D = GameObject.Find("D");
        E = GameObject.Find("E");
        F = GameObject.Find("F");
        G = GameObject.Find("G");
        H = GameObject.Find("H");
        I = GameObject.Find("I");
        J = GameObject.Find("J");
        K = GameObject.Find("K");
        L = GameObject.Find("L");
        M = GameObject.Find("M");
        N = GameObject.Find("N");
        O = GameObject.Find("O");
        P = GameObject.Find("P");
        Q = GameObject.Find("Q");
        R = GameObject.Find("R");
        S = GameObject.Find("S");
        T = GameObject.Find("T");
        U = GameObject.Find("U");
        V = GameObject.Find("V");
        W = GameObject.Find("W");
        X = GameObject.Find("X");
        Y = GameObject.Find("Y");
        Z = GameObject.Find("Z");

        ZERO = GameObject.Find("00");
        ONE = GameObject.Find("11");
        TWO = GameObject.Find("22");
        THREE = GameObject.Find("33");
        FOUR = GameObject.Find("44");
        FIVE = GameObject.Find("55");
        SIX = GameObject.Find("66");
        SEVEN = GameObject.Find("77");
        EIGHT = GameObject.Find("88");
        NINE = GameObject.Find("99");

    }

    protected virtual void Start()
    {
        FindingAssets();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
        
    }

    #endregion // PROTECTED_METHODS
}
