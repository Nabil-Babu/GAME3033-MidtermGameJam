using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ColorState
{
    RED,
    GREEN,
    BLUE
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float strafeSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject hitPoint; 
    [SerializeField] private GameObject pauseMenu; 
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    
    
    // Components
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;
    private PlayerState _playerState;
    private HealthBar _healthBar;

    // Cached References
    private Transform _playerTransform;
    
    private Vector2 _inputVector = Vector2.zero;
    private Vector3 _moveDirection = Vector3.zero;
    
    //Player Stats
    public ColorState currentColor; 
    
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int RunBackward = Animator.StringToHash("Run Backward");
    private static readonly int StrafeRight = Animator.StringToHash("Strafe Right");
    private static readonly int StrafeLeft = Animator.StringToHash("Strafe Left");
    private static readonly int AttackHash1 = Animator.StringToHash("Melee Right Attack 01");
    private static readonly int AttackHash2 = Animator.StringToHash("Melee Right Attack 02");
    private static readonly int AttackHash3 = Animator.StringToHash("Melee Right Attack 03");
    private static readonly int DefendHash = Animator.StringToHash("Defend");
    private static readonly int PotionHash = Animator.StringToHash("Drink Potion");
    private static readonly int DieHash = Animator.StringToHash("Die");

    void Awake()
    {
        _playerTransform = transform;
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerState = GetComponent<PlayerState>();
        _healthBar = GetComponent<HealthBar>();
        currentColor = ColorState.GREEN; 
        pauseMenu.SetActive(false);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void OnMovement(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
        AnimateMovement();
    }

    public void OnPauseMenu(InputValue value)
    {
        if (value.isPressed)
        {
            PauseGame();
        }
    }

    public void OnAttack(InputValue value)
    {
        if (_playerState.isDefending) return;
        if (value.isPressed)
        {
            StartCoroutine(StartAttack());
        }
    }

    public void OnRedMode(InputValue value)
    {
        if(value.isPressed) currentColor = ColorState.RED;
        _playerAnimator.SetTrigger(PotionHash);
    }
    public void OnGreenMode(InputValue value)
    {
        if(value.isPressed) currentColor = ColorState.GREEN;
        _playerAnimator.SetTrigger(PotionHash);
    }
    public void OnBlueMode(InputValue value)
    {
        if(value.isPressed) currentColor = ColorState.BLUE;
        _playerAnimator.SetTrigger(PotionHash);
    }

    public void OnDefend(InputValue value)
    {
        if (value.isPressed)
        {
            _playerAnimator.SetBool(DefendHash, true);
            _playerState.isDefending = true;
            _playerState.isRunning = false;
            _playerState.isStrafing = false;
            
            _playerAnimator.SetBool(StrafeRight, false);
            _playerAnimator.SetBool(StrafeLeft, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(RunBackward, false);
        }
        else
        {
            _playerAnimator.SetBool(DefendHash, false);
            _playerState.isDefending = false;
            AnimateMovement();      
        }
    }

    public void AnimateMovement()
    {
        
        if (_inputVector.y > 0)
        {
            _playerAnimator.SetBool(Run, true);
            _playerAnimator.SetBool(RunBackward, false);
            _playerState.isRunning = true; 
        }
        else if(_inputVector.y < 0)
        {
            _playerAnimator.SetBool(RunBackward, true);
            _playerAnimator.SetBool(Run, false);
            _playerState.isRunning = true;
        }
        else
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(RunBackward, false);
            _playerState.isRunning = false;
        }
        
        if (_inputVector.x > 0)
        {
            _playerAnimator.SetBool(StrafeRight, true);
            _playerAnimator.SetBool(StrafeLeft, false);
            if(!_playerState.isRunning) _playerState.isStrafing = true; 
        }
        else if(_inputVector.x < 0)
        {
            _playerAnimator.SetBool(StrafeRight, false);
            _playerAnimator.SetBool(StrafeLeft, true);
            if(!_playerState.isRunning) _playerState.isStrafing = true; 
        }
        else
        {
            _playerAnimator.SetBool(StrafeRight, false);
            _playerAnimator.SetBool(StrafeLeft, false);
            _playerState.isStrafing = false; 
        }

         
    }

    private void Update()
    {
        if (_playerState.isDead) return; 
        if (_playerState.isDefending) return;
        _playerState.isIdling = !(_inputVector.sqrMagnitude > 0);
        if (!(_inputVector.sqrMagnitude > 0)) _moveDirection = Vector3.zero;
        _moveDirection = _playerTransform.forward * _inputVector.y + _playerTransform.right * _inputVector.x;
        float currentSpeed = _playerState.isStrafing ? strafeSpeed : runSpeed; 
        Vector3 movementDirection = _moveDirection * (currentSpeed * Time.deltaTime);
        _playerTransform.position += movementDirection;
        
        _healthBar.UpdateColor(currentColor);
    }

    private void CheckHitPoint()
    {
        RaycastHit[] hits = Physics.BoxCastAll(hitPoint.transform.position, Vector3.one/2, transform.forward, Quaternion.identity, 0.0f);
        if (hits.Length > 0)
        {
            audioSource.PlayOneShot(hitSound);
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent<EnemyBehaviour>(out var enemy))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    enemy.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
                    if (enemy.currentColor == currentColor)
                    {
                        enemy.TakeDamage(50);
                    }
                    else
                    {
                        enemy.TakeDamage(10);
                    }
                }
            }
        }
    }

    IEnumerator StartAttack()
    {
        _playerAnimator.SetTrigger(AttackHash2);
        _playerState.isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        CheckHitPoint();
        yield return new WaitForSeconds(0.2f);
        _playerState.isAttacking = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        if (pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void TakeDamage(float amount)
    {
        if (_playerState.isDead) return;
        _healthBar.TakeDamage(amount);

        if (_healthBar.currentHealth <= 0)
        {
            _playerAnimator.SetTrigger(DieHash);
            _playerState.isDead = true;
            gameManager.GameOver();
        }
    }
}
