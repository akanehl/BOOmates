// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Aaron/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
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
                },
                {
                    ""name"": ""Hide"",
                    ""type"": ""Button"",
                    ""id"": ""1afbe2fd-e35c-4072-983c-71e3c8ce8db2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Invis"",
                    ""type"": ""Button"",
                    ""id"": ""9e99b3b3-1f27-4490-8114-6624d21c9cc9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Appear"",
                    ""type"": ""Button"",
                    ""id"": ""721cb5b7-3f25-49d8-9d88-4f3a3afa3bf8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Taking"",
                    ""type"": ""Button"",
                    ""id"": ""6817fc1b-9269-4f2a-b761-abb17233588f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leaving"",
                    ""type"": ""Button"",
                    ""id"": ""e3f7035f-6a12-4271-9aac-f9ac70e884fc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grabbing"",
                    ""type"": ""Button"",
                    ""id"": ""21a34b82-ed48-4e09-98bd-179d4f9c4529"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Title"",
                    ""type"": ""Button"",
                    ""id"": ""6d203c19-2494-49b7-8b54-7547cf2eb8fa"",
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
                    ""path"": ""<Gamepad>/buttonWest"",
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
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Music"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0804857-4988-4285-a9f3-47edee4e0899"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Invis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68424d5a-654f-4037-b070-3bae0a9954ad"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Appear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40a509aa-1cf7-4ff8-8f26-406c8839bf0b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ca64396-ce4c-40cf-aa2e-6ce1a6293be3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Taking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fc04662-5e9b-4d80-a4a9-9e69d38cc859"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leaving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f97185ff-800a-4fc1-b853-038afe6e3562"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grabbing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a121b69e-b59e-48d7-9f56-1e4cee62e429"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Title"",
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
        m_Gameplay_Hide = m_Gameplay.FindAction("Hide", throwIfNotFound: true);
        m_Gameplay_Invis = m_Gameplay.FindAction("Invis", throwIfNotFound: true);
        m_Gameplay_Appear = m_Gameplay.FindAction("Appear", throwIfNotFound: true);
        m_Gameplay_Taking = m_Gameplay.FindAction("Taking", throwIfNotFound: true);
        m_Gameplay_Leaving = m_Gameplay.FindAction("Leaving", throwIfNotFound: true);
        m_Gameplay_Grabbing = m_Gameplay.FindAction("Grabbing", throwIfNotFound: true);
        m_Gameplay_Title = m_Gameplay.FindAction("Title", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Hide;
    private readonly InputAction m_Gameplay_Invis;
    private readonly InputAction m_Gameplay_Appear;
    private readonly InputAction m_Gameplay_Taking;
    private readonly InputAction m_Gameplay_Leaving;
    private readonly InputAction m_Gameplay_Grabbing;
    private readonly InputAction m_Gameplay_Title;
    public struct GameplayActions
    {
        private @Controller m_Wrapper;
        public GameplayActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Punch => m_Wrapper.m_Gameplay_Punch;
        public InputAction @Launch => m_Wrapper.m_Gameplay_Launch;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Lights => m_Wrapper.m_Gameplay_Lights;
        public InputAction @Music => m_Wrapper.m_Gameplay_Music;
        public InputAction @Hide => m_Wrapper.m_Gameplay_Hide;
        public InputAction @Invis => m_Wrapper.m_Gameplay_Invis;
        public InputAction @Appear => m_Wrapper.m_Gameplay_Appear;
        public InputAction @Taking => m_Wrapper.m_Gameplay_Taking;
        public InputAction @Leaving => m_Wrapper.m_Gameplay_Leaving;
        public InputAction @Grabbing => m_Wrapper.m_Gameplay_Grabbing;
        public InputAction @Title => m_Wrapper.m_Gameplay_Title;
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
                @Hide.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHide;
                @Hide.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHide;
                @Hide.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHide;
                @Invis.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInvis;
                @Invis.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInvis;
                @Invis.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInvis;
                @Appear.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAppear;
                @Appear.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAppear;
                @Appear.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAppear;
                @Taking.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTaking;
                @Taking.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTaking;
                @Taking.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTaking;
                @Leaving.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeaving;
                @Leaving.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeaving;
                @Leaving.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeaving;
                @Grabbing.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrabbing;
                @Grabbing.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrabbing;
                @Grabbing.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrabbing;
                @Title.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTitle;
                @Title.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTitle;
                @Title.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTitle;
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
                @Hide.started += instance.OnHide;
                @Hide.performed += instance.OnHide;
                @Hide.canceled += instance.OnHide;
                @Invis.started += instance.OnInvis;
                @Invis.performed += instance.OnInvis;
                @Invis.canceled += instance.OnInvis;
                @Appear.started += instance.OnAppear;
                @Appear.performed += instance.OnAppear;
                @Appear.canceled += instance.OnAppear;
                @Taking.started += instance.OnTaking;
                @Taking.performed += instance.OnTaking;
                @Taking.canceled += instance.OnTaking;
                @Leaving.started += instance.OnLeaving;
                @Leaving.performed += instance.OnLeaving;
                @Leaving.canceled += instance.OnLeaving;
                @Grabbing.started += instance.OnGrabbing;
                @Grabbing.performed += instance.OnGrabbing;
                @Grabbing.canceled += instance.OnGrabbing;
                @Title.started += instance.OnTitle;
                @Title.performed += instance.OnTitle;
                @Title.canceled += instance.OnTitle;
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
        void OnHide(InputAction.CallbackContext context);
        void OnInvis(InputAction.CallbackContext context);
        void OnAppear(InputAction.CallbackContext context);
        void OnTaking(InputAction.CallbackContext context);
        void OnLeaving(InputAction.CallbackContext context);
        void OnGrabbing(InputAction.CallbackContext context);
        void OnTitle(InputAction.CallbackContext context);
    }
}
