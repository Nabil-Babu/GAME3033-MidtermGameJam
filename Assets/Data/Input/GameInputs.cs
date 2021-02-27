// GENERATED AUTOMATICALLY FROM 'Assets/Data/Input/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""ThirdPerson"",
            ""id"": ""c9ac22aa-48ce-4c4b-b72a-a696d0920cbf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4930af67-adf9-483a-826f-dcdf694c43bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""67dc1e87-f90a-4034-9798-a46ba8923783"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""15f0339e-395e-4c4c-a572-306b52206c96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""2fd33076-d7a6-4233-ae5d-de25bf7251a2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""0fde047a-eb52-4775-b994-4d38c2156645"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RedMode"",
                    ""type"": ""Button"",
                    ""id"": ""b5365134-7461-4ae3-a852-e16f5be31f95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GreenMode"",
                    ""type"": ""Button"",
                    ""id"": ""4bf77848-1a52-4e59-a0fd-aa4eefd1cf73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""BlueMode"",
                    ""type"": ""Button"",
                    ""id"": ""3d3c8dd4-d27e-4255-adab-daa3303fae61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""13d9f3d1-7613-4302-afdc-f54d4eee7e95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""de1519b5-a330-46e6-addf-6c77b1216277"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ba4dbfba-6506-4094-8aea-ea05ed2d5891"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cdf31715-8326-41c5-b60e-6f24bfbc4153"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""72298114-b715-495e-9d24-9b88fec236d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f406f20-837d-4948-a5f8-beaf83b58633"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""76d3bc39-fe4e-4639-b0ec-636c638dd89d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b56d2ed3-88f5-4be7-b758-8f33598459bd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e5d7f9d-acce-47b8-b29d-ef44b1e1f08d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adea9b48-e413-4217-8021-d3ea8073ee26"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8c3c01c-2930-47af-9208-23237dcc5817"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RedMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f32aea6e-e5a0-4dbc-ad86-0f52cfa13f91"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GreenMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e511c53-4ae0-4f5a-834d-94e8c080645f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlueMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9d8fc1-a8d9-42fc-b69f-54d2e9913e10"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ThirdPerson
        m_ThirdPerson = asset.FindActionMap("ThirdPerson", throwIfNotFound: true);
        m_ThirdPerson_Movement = m_ThirdPerson.FindAction("Movement", throwIfNotFound: true);
        m_ThirdPerson_Jump = m_ThirdPerson.FindAction("Jump", throwIfNotFound: true);
        m_ThirdPerson_Attack = m_ThirdPerson.FindAction("Attack", throwIfNotFound: true);
        m_ThirdPerson_Look = m_ThirdPerson.FindAction("Look", throwIfNotFound: true);
        m_ThirdPerson_Defend = m_ThirdPerson.FindAction("Defend", throwIfNotFound: true);
        m_ThirdPerson_RedMode = m_ThirdPerson.FindAction("RedMode", throwIfNotFound: true);
        m_ThirdPerson_GreenMode = m_ThirdPerson.FindAction("GreenMode", throwIfNotFound: true);
        m_ThirdPerson_BlueMode = m_ThirdPerson.FindAction("BlueMode", throwIfNotFound: true);
        m_ThirdPerson_PauseMenu = m_ThirdPerson.FindAction("PauseMenu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ThirdPerson
    private readonly InputActionMap m_ThirdPerson;
    private IThirdPersonActions m_ThirdPersonActionsCallbackInterface;
    private readonly InputAction m_ThirdPerson_Movement;
    private readonly InputAction m_ThirdPerson_Jump;
    private readonly InputAction m_ThirdPerson_Attack;
    private readonly InputAction m_ThirdPerson_Look;
    private readonly InputAction m_ThirdPerson_Defend;
    private readonly InputAction m_ThirdPerson_RedMode;
    private readonly InputAction m_ThirdPerson_GreenMode;
    private readonly InputAction m_ThirdPerson_BlueMode;
    private readonly InputAction m_ThirdPerson_PauseMenu;
    public struct ThirdPersonActions
    {
        private @GameInputs m_Wrapper;
        public ThirdPersonActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ThirdPerson_Movement;
        public InputAction @Jump => m_Wrapper.m_ThirdPerson_Jump;
        public InputAction @Attack => m_Wrapper.m_ThirdPerson_Attack;
        public InputAction @Look => m_Wrapper.m_ThirdPerson_Look;
        public InputAction @Defend => m_Wrapper.m_ThirdPerson_Defend;
        public InputAction @RedMode => m_Wrapper.m_ThirdPerson_RedMode;
        public InputAction @GreenMode => m_Wrapper.m_ThirdPerson_GreenMode;
        public InputAction @BlueMode => m_Wrapper.m_ThirdPerson_BlueMode;
        public InputAction @PauseMenu => m_Wrapper.m_ThirdPerson_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_ThirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IThirdPersonActions instance)
        {
            if (m_Wrapper.m_ThirdPersonActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
                @Look.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Defend.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDefend;
                @Defend.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDefend;
                @Defend.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDefend;
                @RedMode.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRedMode;
                @RedMode.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRedMode;
                @RedMode.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRedMode;
                @GreenMode.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnGreenMode;
                @GreenMode.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnGreenMode;
                @GreenMode.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnGreenMode;
                @BlueMode.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnBlueMode;
                @BlueMode.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnBlueMode;
                @BlueMode.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnBlueMode;
                @PauseMenu.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_ThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Defend.started += instance.OnDefend;
                @Defend.performed += instance.OnDefend;
                @Defend.canceled += instance.OnDefend;
                @RedMode.started += instance.OnRedMode;
                @RedMode.performed += instance.OnRedMode;
                @RedMode.canceled += instance.OnRedMode;
                @GreenMode.started += instance.OnGreenMode;
                @GreenMode.performed += instance.OnGreenMode;
                @GreenMode.canceled += instance.OnGreenMode;
                @BlueMode.started += instance.OnBlueMode;
                @BlueMode.performed += instance.OnBlueMode;
                @BlueMode.canceled += instance.OnBlueMode;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public ThirdPersonActions @ThirdPerson => new ThirdPersonActions(this);
    public interface IThirdPersonActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnRedMode(InputAction.CallbackContext context);
        void OnGreenMode(InputAction.CallbackContext context);
        void OnBlueMode(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}
