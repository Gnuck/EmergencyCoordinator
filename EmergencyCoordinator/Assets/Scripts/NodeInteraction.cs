// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Academy
{
    /// <summary>
    /// The Interactible class flags a Game Object as being "Interactible".
    /// Determines what happens when an Interactible is being gazed at.
    /// </summary>
    public class NodeInteraction : MonoBehaviour, IFocusable, IInputClickHandler
    {
        [Tooltip("Audio clip to play when interacting with this hologram.")]
        public AudioClip TargetFeedbackSound;
        private AudioSource audioSource;

        private Material[] defaultMaterials;
        private Material m_Material;

        [SerializeField]
        private InteractibleAction interactibleAction;

        private void Start()
        {
            defaultMaterials = GetComponent<Renderer>().materials;
            Debug.Log(defaultMaterials);
            // Add a BoxCollider if the interactible does not contain one.
            Collider collider = GetComponentInChildren<Collider>();
            if (collider == null)
            {
                gameObject.AddComponent<BoxCollider>();
            }

            EnableAudioHapticFeedback();

            m_Material = GetComponent<Renderer>().material;

            //Set the main Color of the Material to green
            Debug.Log(m_Material.shader.name);
        }

        private void EnableAudioHapticFeedback()
        {
            // If this hologram has an audio clip, add an AudioSource with this clip.
            if (TargetFeedbackSound != null)
            {
                audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }

                audioSource.clip = TargetFeedbackSound;
                audioSource.playOnAwake = false;
                audioSource.spatialBlend = 1;
                audioSource.dopplerLevel = 0;
            }
        }

        /* TODO: DEVELOPER CODING EXERCISE 2.d */

        void IFocusable.OnFocusEnter()
        {
        }

        void IFocusable.OnFocusExit()
        {
        }

        void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
        {
            // Play the audioSource feedback when we gaze and select a hologram.
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            /* TODO: DEVELOPER CODING EXERCISE 6.a */
            // 6.a: Uncomment the lines below to perform a Tagalong action.
            if (interactibleAction != null)
            {
                interactibleAction.PerformAction();
            }
            //m_Material.color = Color.red;
            SetupManager.Instance.selectNode(gameObject);
        }

        private void OnDestroy()
        {
            foreach (Material material in defaultMaterials)
            {
                Destroy(material);
            }
        }
    }
}