// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/MyHumanController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyHumanController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyHumanController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyHumanController"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""aa05514f-da86-4741-907a-61020a5fb6b6"",
            ""actions"": [
                {
                    ""name"": ""TakeBody"",
                    ""type"": ""Button"",
                    ""id"": ""af101261-6061-4372-9d4d-df8aa87ce609"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeaveBody"",
                    ""type"": ""Button"",
                    ""id"": ""26f314dd-eaf3-4e42-8e59-da1bdaf4b90f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MyMovement"",
                    ""type"": ""Button"",
                    ""id"": ""29442f6d-4014-4d43-8ad7-74dce50a9ca1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""6c980e87-ce4b-463d-a4d5-400a2e1c1690"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Clean"",
                    ""type"": ""Button"",
                    ""id"": ""06911a8f-032e-4b02-8398-74bed8a52ab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c2d6810-3e3d-455c-9deb-bcc92d7ba1a4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TakeBody"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3530d95f-92b0-4a3d-8eb7-8fcc3c3abe3d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeaveBody"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e8936be-7c84-45be-b950-9b4fa13f9b0e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MyMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1d6463-1799-4d88-84c0-99c5c0b8e6cd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d232ac4-0c25-4e33-872e-1fba9805a1b5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_TakeBody = m_GamePlay.FindAction("TakeBody", throwIfNotFound: true);
        m_GamePlay_LeaveBody = m_GamePlay.FindAction("LeaveBody", throwIfNotFound: true);
        m_GamePlay_MyMovement = m_GamePlay.FindAction("MyMovement", throwIfNotFound: true);
        m_GamePlay_Grab = m_GamePlay.FindAction("Grab", throwIfNotFound: true);
        m_GamePlay_Clean = m_GamePlay.FindAction("Clean", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_TakeBody;
    private readonly InputAction m_GamePlay_LeaveBody;
    private readonly InputAction m_GamePlay_MyMovement;
    private readonly InputAction m_GamePlay_Grab;
    private readonly InputAction m_GamePlay_Clean;
    public struct GamePlayActions
    {
        private @MyHumanController m_Wrapper;
        public GamePlayActions(@MyHumanController wrapper) { m_Wrapper = wrapper; }
        public InputAction @TakeBody => m_Wrapper.m_GamePlay_TakeBody;
        public InputAction @LeaveBody => m_Wrapper.m_GamePlay_LeaveBody;
        public InputAction @MyMovement => m_Wrapper.m_GamePlay_MyMovement;
        public InputAction @Grab => m_Wrapper.m_GamePlay_Grab;
        public InputAction @Clean => m_Wrapper.m_GamePlay_Clean;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @TakeBody.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTakeBody;
                @TakeBody.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTakeBody;
                @TakeBody.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTakeBody;
                @LeaveBody.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLeaveBody;
                @LeaveBody.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLeaveBody;
                @LeaveBody.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLeaveBody;
                @MyMovement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMyMovement;
                @MyMovement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMyMovement;
                @MyMovement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMyMovement;
                @Grab.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Clean.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClean;
                @Clean.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClean;
                @Clean.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClean;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TakeBody.started += instance.OnTakeBody;
                @TakeBody.performed += instance.OnTakeBody;
                @TakeBody.canceled += instance.OnTakeBody;
                @LeaveBody.started += instance.OnLeaveBody;
                @LeaveBody.performed += instance.OnLeaveBody;
                @LeaveBody.canceled += instance.OnLeaveBody;
                @MyMovement.started += instance.OnMyMovement;
                @MyMovement.performed += instance.OnMyMovement;
                @MyMovement.canceled += instance.OnMyMovement;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Clean.started += instance.OnClean;
                @Clean.performed += instance.OnClean;
                @Clean.canceled += instance.OnClean;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnTakeBody(InputAction.CallbackContext context);
        void OnLeaveBody(InputAction.CallbackContext context);
        void OnMyMovement(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnClean(InputAction.CallbackContext context);
    }
}
