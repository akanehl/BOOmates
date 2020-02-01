// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ece6465f-075c-48d2-87a6-999c9a9d3f43"",
            ""actions"": [
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""83ed8a74-1c70-4703-8c39-b56ac0296e04"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""ff025102-a165-4ca2-9c2b-0c1c970762fe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1d422bf1-df02-4e28-ade0-5204369b1383"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lights"",
                    ""type"": ""Button"",
                    ""id"": ""b2909795-f639-430b-859f-3c5a7a5c490a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Music"",
                    ""type"": ""Button"",
                    ""id"": ""f3d45bc6-2b5b-40d2-92c3-76df8b8667d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd8fa655-ef9b-4f79-91a2-e62999f60602"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20404468-e95a-4f6a-9f15-1557af36d40a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""808c7711-5774-4ccc-95e4-c93384aba095"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18d6089c-cc8a-49ce-a001-fa5fe394282f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c419678-18cf-40dd-852d-d5bf2844765e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Music"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Punch = m_Gameplay.FindAction("Punch", throwIfNotFound: true);
        m_Gameplay_Launch = m_Gameplay.FindAction("Launch", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Lights = m_Gameplay.FindAction("Lights", throwIfNotFound: true);
        m_Gameplay_Music = m_Gameplay.FindAction("Music", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Punch;
    private readonly InputAction m_Gameplay_Launch;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Lights;
    private readonly InputAction m_Gameplay_Music;
    public struct GameplayActions
    {
        private @Controller m_Wrapper;
        public GameplayActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Punch => m_Wrapper.m_Gameplay_Punch;
        public InputAction @Launch => m_Wrapper.m_Gameplay_Launch;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Lights => m_Wrapper.m_Gameplay_Lights;
        public InputAction @Music => m_Wrapper.m_Gameplay_Music;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Punch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Launch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Lights.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLights;
                @Lights.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLights;
                @Lights.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLights;
                @Music.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMusic;
                @Music.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMusic;
                @Music.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMusic;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Lights.started += instance.OnLights;
                @Lights.performed += instance.OnLights;
                @Lights.canceled += instance.OnLights;
                @Music.started += instance.OnMusic;
                @Music.performed += instance.OnMusic;
                @Music.canceled += instance.OnMusic;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnPunch(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnLights(InputAction.CallbackContext context);
        void OnMusic(InputAction.CallbackContext context);
    }
}
