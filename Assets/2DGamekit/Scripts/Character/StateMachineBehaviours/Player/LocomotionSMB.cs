﻿using UnityEngine;

namespace Gamekit2D
{
    public class LocomotionSMB : SceneLinkedSMB<PlayerCharacter>
    {
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        public override void OnSLStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.TeleportToColliderBottom();
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.UpdateFacing();
            m_MonoBehaviour.GroundedHorizontalMovement(true);
            m_MonoBehaviour.GroundedVerticalMovement();
            m_MonoBehaviour.CheckForCrouching();
            m_MonoBehaviour.CheckForGrounded();
            m_MonoBehaviour.CheckForPushing();
            m_MonoBehaviour.CheckForHoldingGun();
            m_MonoBehaviour.CheckAndFireGun ();
            if (m_MonoBehaviour.CheckForJumpInput())
            {
                m_MonoBehaviour.SetVerticalMovement(m_MonoBehaviour.jumpSpeed);
                if(audioManager == null)
                    audioManager = FindObjectOfType<AudioManager>();
                audioManager.PlayJump();
            }

            else if (m_MonoBehaviour.CheckForMeleeAttackInput())
                m_MonoBehaviour.MeleeAttack();
        }
    }
}