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
                    ""name"": ""Dash"",
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
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""674c255a-13a7-4e4b-a7ec-3b0cee575929"",
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
                    ""action"": ""Dash"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""84bc036a-2b94-4f15-93b6-2089b0ef9294"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay1"",
            ""id"": ""9749596a-3b55-4496-95ad-bf0797747231"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""c992905f-674b-4567-a9e4-2b05e1e04e7a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""f3587d79-db80-42db-bbf3-8294f3130e8c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lights"",
                    ""type"": ""Button"",
                    ""id"": ""507462ba-69d1-4cb6-b68b-76f686f773ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Music"",
                    ""type"": ""Button"",
                    ""id"": ""7818ce5e-a4b4-4d39-8a51-02d4b5abc8f3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hide"",
                    ""type"": ""Button"",
                    ""id"": ""92d0562e-8849-4523-aca7-37a6b9ba84c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Invis"",
                    ""type"": ""Button"",
                    ""id"": ""02a0264c-135a-4d3c-b716-6e343a01e90d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Appear"",
                    ""type"": ""Button"",
                    ""id"": ""47a7e3ba-c222-4054-94c9-fcb8fa4d8f1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Taking"",
                    ""type"": ""Button"",
                    ""id"": ""111cedb9-23f2-43f1-91ec-a71ca929716e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leaving"",
                    ""type"": ""Button"",
                    ""id"": ""a81668f7-5592-498e-94f0-7a22fbfdc725"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grabbing"",
                    ""type"": ""Button"",
                    ""id"": ""18d24280-84a9-4bcb-8e54-52c707540360"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Title"",
                    ""type"": ""Button"",
                    ""id"": ""ec8362d6-c066-458e-ac46-99b1103c008b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""d25aae96-6389-403d-979d-7f1fae43c60f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8d9038c-69ca-4d60-9ca0-3518a0ae7982"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""163b0e31-c626-441a-b781-99adaa9feea2"",
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
                    ""id"": ""79b6b92b-ce17-4907-9b37-55c06e93bfd2"",
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
                    ""id"": ""536cbfb7-f5cf-4140-b592-4881b5413655"",
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
                    ""id"": ""9a6a858f-c84f-44e8-a411-5e337529ad5c"",
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
                    ""id"": ""79bbda65-efeb-41eb-acf2-195fe76f0468"",
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
                    ""id"": ""dd0d81bc-465e-4eac-8d73-6685ad46f74b"",
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
                    ""id"": ""e8e75824-01e6-4e0b-9038-babfa84bc136"",
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
                    ""id"": ""7b0b7156-9778-4bdf-b0fd-45051e8204ed"",
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
                    ""id"": ""6c5fc5e5-f9e6-49c2-903f-61f1f0bbfbe7"",
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
                    ""id"": ""6313872f-9932-4f3a-b6a1-68a1edcf5564"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3632d9d3-7241-413a-82c8-bb023069a1bc"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay2"",
            ""id"": ""465fe6c9-9d96-4772-8a7b-b6c8687bbce4"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""6359f0fb-b5ac-40b8-964a-816ebca3e9b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""02303151-b017-46ad-b0d9-5341d8144035"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lights"",
                    ""type"": ""Button"",
                    ""id"": ""d46ef70b-805b-4851-9774-c88adc52e6b1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Music"",
                    ""type"": ""Button"",
                    ""id"": ""d9e02a51-2bdb-4b72-a8db-596a54cc2461"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hide"",
                    ""type"": ""Button"",
                    ""id"": ""76b91260-7170-43e4-8be7-ea119cb28e37"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Invis"",
                    ""type"": ""Button"",
                    ""id"": ""90280bb9-ca72-451d-8389-3b48c92cef05"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Appear"",
                    ""type"": ""Button"",
                    ""id"": ""92c60e8e-25fe-4490-8a48-86a3032e47ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Taking"",
                    ""type"": ""Button"",
                    ""id"": ""18090ec4-0581-4c26-9076-b558eceec454"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leaving"",
                    ""type"": ""Button"",
                    ""id"": ""cec2770c-c0d0-45d6-9f7f-a8fbfa27858d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grabbing"",
                    ""type"": ""Button"",
                    ""id"": ""a49fcbba-0a2c-4364-b3d8-783a146fa364"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Title"",
                    ""type"": ""Button"",
                    ""id"": ""a76ea000-f31a-4640-a078-4a60d51ac191"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""7b187007-e656-4659-9c8a-5272be3edfcf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6d4b13a3-90bb-4630-b179-7709cc4ec241"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b8c980b-cccb-4893-ac5e-36280ff97128"",
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
                    ""id"": ""79bd388e-2d73-4e89-aaa4-9f60c69f225c"",
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
                    ""id"": ""20cb9b38-96f4-4852-a287-9dc477c70763"",
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
                    ""id"": ""c90aa39c-4101-47cf-948f-84768b9bb2b9"",
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
                    ""id"": ""49e1cc3b-f4db-4a1c-a48e-0b7dacdf3971"",
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
                    ""id"": ""b94f5165-9606-4eb3-b041-28421214f076"",
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
                    ""id"": ""1b48592b-bf75-404d-9bc7-f881b54f085c"",
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
                    ""id"": ""0541b093-3d7e-4f06-b5f2-0d6f8b814bd6"",
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
                    ""id"": ""7e2461a3-39ec-48c8-846f-11194d8db8d7"",
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
                    ""id"": ""c2c90afb-47e0-4d6d-b46a-36071449d29e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67ea7aab-dc3f-45e1-91db-2c773b8e3d5f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
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
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Launch = m_Gameplay.FindAction("Launch", throwIfNotFound: true);
        m_Gameplay_Lights = m_Gameplay.FindAction("Lights", throwIfNotFound: true);
        m_Gameplay_Music = m_Gameplay.FindAction("Music", throwIfNotFound: true);
        m_Gameplay_Hide = m_Gameplay.FindAction("Hide", throwIfNotFound: true);
        m_Gameplay_Invis = m_Gameplay.FindAction("Invis", throwIfNotFound: true);
        m_Gameplay_Appear = m_Gameplay.FindAction("Appear", throwIfNotFound: true);
        m_Gameplay_Taking = m_Gameplay.FindAction("Taking", throwIfNotFound: true);
        m_Gameplay_Leaving = m_Gameplay.FindAction("Leaving", throwIfNotFound: true);
        m_Gameplay_Grabbing = m_Gameplay.FindAction("Grabbing", throwIfNotFound: true);
        m_Gameplay_Title = m_Gameplay.FindAction("Title", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        // Gameplay1
        m_Gameplay1 = asset.FindActionMap("Gameplay1", throwIfNotFound: true);
        m_Gameplay1_Dash = m_Gameplay1.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay1_Launch = m_Gameplay1.FindAction("Launch", throwIfNotFound: true);
        m_Gameplay1_Lights = m_Gameplay1.FindAction("Lights", throwIfNotFound: true);
        m_Gameplay1_Music = m_Gameplay1.FindAction("Music", throwIfNotFound: true);
        m_Gameplay1_Hide = m_Gameplay1.FindAction("Hide", throwIfNotFound: true);
        m_Gameplay1_Invis = m_Gameplay1.FindAction("Invis", throwIfNotFound: true);
        m_Gameplay1_Appear = m_Gameplay1.FindAction("Appear", throwIfNotFound: true);
        m_Gameplay1_Taking = m_Gameplay1.FindAction("Taking", throwIfNotFound: true);
        m_Gameplay1_Leaving = m_Gameplay1.FindAction("Leaving", throwIfNotFound: true);
        m_Gameplay1_Grabbing = m_Gameplay1.FindAction("Grabbing", throwIfNotFound: true);
        m_Gameplay1_Title = m_Gameplay1.FindAction("Title", throwIfNotFound: true);
        m_Gameplay1_Newaction = m_Gameplay1.FindAction("New action", throwIfNotFound: true);
        // Gameplay2
        m_Gameplay2 = asset.FindActionMap("Gameplay2", throwIfNotFound: true);
        m_Gameplay2_Dash = m_Gameplay2.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay2_Launch = m_Gameplay2.FindAction("Launch", throwIfNotFound: true);
        m_Gameplay2_Lights = m_Gameplay2.FindAction("Lights", throwIfNotFound: true);
        m_Gameplay2_Music = m_Gameplay2.FindAction("Music", throwIfNotFound: true);
        m_Gameplay2_Hide = m_Gameplay2.FindAction("Hide", throwIfNotFound: true);
        m_Gameplay2_Invis = m_Gameplay2.FindAction("Invis", throwIfNotFound: true);
        m_Gameplay2_Appear = m_Gameplay2.FindAction("Appear", throwIfNotFound: true);
        m_Gameplay2_Taking = m_Gameplay2.FindAction("Taking", throwIfNotFound: true);
        m_Gameplay2_Leaving = m_Gameplay2.FindAction("Leaving", throwIfNotFound: true);
        m_Gameplay2_Grabbing = m_Gameplay2.FindAction("Grabbing", throwIfNotFound: true);
        m_Gameplay2_Title = m_Gameplay2.FindAction("Title", throwIfNotFound: true);
        m_Gameplay2_Movement = m_Gameplay2.FindAction("Movement", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Launch;
    private readonly InputAction m_Gameplay_Lights;
    private readonly InputAction m_Gameplay_Music;
    private readonly InputAction m_Gameplay_Hide;
    private readonly InputAction m_Gameplay_Invis;
    private readonly InputAction m_Gameplay_Appear;
    private readonly InputAction m_Gameplay_Taking;
    private readonly InputAction m_Gameplay_Leaving;
    private readonly InputAction m_Gameplay_Grabbing;
    private readonly InputAction m_Gameplay_Title;
    private readonly InputAction m_Gameplay_Movement;
    public struct GameplayActions
    {
        private @Controller m_Wrapper;
        public GameplayActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Launch => m_Wrapper.m_Gameplay_Launch;
        public InputAction @Lights => m_Wrapper.m_Gameplay_Lights;
        public InputAction @Music => m_Wrapper.m_Gameplay_Music;
        public InputAction @Hide => m_Wrapper.m_Gameplay_Hide;
        public InputAction @Invis => m_Wrapper.m_Gameplay_Invis;
        public InputAction @Appear => m_Wrapper.m_Gameplay_Appear;
        public InputAction @Taking => m_Wrapper.m_Gameplay_Taking;
        public InputAction @Leaving => m_Wrapper.m_Gameplay_Leaving;
        public InputAction @Grabbing => m_Wrapper.m_Gameplay_Grabbing;
        public InputAction @Title => m_Wrapper.m_Gameplay_Title;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Launch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLaunch;
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
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
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
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Gameplay1
    private readonly InputActionMap m_Gameplay1;
    private IGameplay1Actions m_Gameplay1ActionsCallbackInterface;
    private readonly InputAction m_Gameplay1_Dash;
    private readonly InputAction m_Gameplay1_Launch;
    private readonly InputAction m_Gameplay1_Lights;
    private readonly InputAction m_Gameplay1_Music;
    private readonly InputAction m_Gameplay1_Hide;
    private readonly InputAction m_Gameplay1_Invis;
    private readonly InputAction m_Gameplay1_Appear;
    private readonly InputAction m_Gameplay1_Taking;
    private readonly InputAction m_Gameplay1_Leaving;
    private readonly InputAction m_Gameplay1_Grabbing;
    private readonly InputAction m_Gameplay1_Title;
    private readonly InputAction m_Gameplay1_Newaction;
    public struct Gameplay1Actions
    {
        private @Controller m_Wrapper;
        public Gameplay1Actions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Gameplay1_Dash;
        public InputAction @Launch => m_Wrapper.m_Gameplay1_Launch;
        public InputAction @Lights => m_Wrapper.m_Gameplay1_Lights;
        public InputAction @Music => m_Wrapper.m_Gameplay1_Music;
        public InputAction @Hide => m_Wrapper.m_Gameplay1_Hide;
        public InputAction @Invis => m_Wrapper.m_Gameplay1_Invis;
        public InputAction @Appear => m_Wrapper.m_Gameplay1_Appear;
        public InputAction @Taking => m_Wrapper.m_Gameplay1_Taking;
        public InputAction @Leaving => m_Wrapper.m_Gameplay1_Leaving;
        public InputAction @Grabbing => m_Wrapper.m_Gameplay1_Grabbing;
        public InputAction @Title => m_Wrapper.m_Gameplay1_Title;
        public InputAction @Newaction => m_Wrapper.m_Gameplay1_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay1Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay1Actions instance)
        {
            if (m_Wrapper.m_Gameplay1ActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnDash;
                @Launch.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLaunch;
                @Lights.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLights;
                @Lights.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLights;
                @Lights.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLights;
                @Music.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnMusic;
                @Music.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnMusic;
                @Music.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnMusic;
                @Hide.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnHide;
                @Hide.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnHide;
                @Hide.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnHide;
                @Invis.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnInvis;
                @Invis.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnInvis;
                @Invis.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnInvis;
                @Appear.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAppear;
                @Appear.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAppear;
                @Appear.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAppear;
                @Taking.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTaking;
                @Taking.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTaking;
                @Taking.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTaking;
                @Leaving.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLeaving;
                @Leaving.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLeaving;
                @Leaving.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnLeaving;
                @Grabbing.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnGrabbing;
                @Grabbing.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnGrabbing;
                @Grabbing.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnGrabbing;
                @Title.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTitle;
                @Title.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTitle;
                @Title.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTitle;
                @Newaction.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_Gameplay1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
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
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public Gameplay1Actions @Gameplay1 => new Gameplay1Actions(this);

    // Gameplay2
    private readonly InputActionMap m_Gameplay2;
    private IGameplay2Actions m_Gameplay2ActionsCallbackInterface;
    private readonly InputAction m_Gameplay2_Dash;
    private readonly InputAction m_Gameplay2_Launch;
    private readonly InputAction m_Gameplay2_Lights;
    private readonly InputAction m_Gameplay2_Music;
    private readonly InputAction m_Gameplay2_Hide;
    private readonly InputAction m_Gameplay2_Invis;
    private readonly InputAction m_Gameplay2_Appear;
    private readonly InputAction m_Gameplay2_Taking;
    private readonly InputAction m_Gameplay2_Leaving;
    private readonly InputAction m_Gameplay2_Grabbing;
    private readonly InputAction m_Gameplay2_Title;
    private readonly InputAction m_Gameplay2_Movement;
    public struct Gameplay2Actions
    {
        private @Controller m_Wrapper;
        public Gameplay2Actions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Gameplay2_Dash;
        public InputAction @Launch => m_Wrapper.m_Gameplay2_Launch;
        public InputAction @Lights => m_Wrapper.m_Gameplay2_Lights;
        public InputAction @Music => m_Wrapper.m_Gameplay2_Music;
        public InputAction @Hide => m_Wrapper.m_Gameplay2_Hide;
        public InputAction @Invis => m_Wrapper.m_Gameplay2_Invis;
        public InputAction @Appear => m_Wrapper.m_Gameplay2_Appear;
        public InputAction @Taking => m_Wrapper.m_Gameplay2_Taking;
        public InputAction @Leaving => m_Wrapper.m_Gameplay2_Leaving;
        public InputAction @Grabbing => m_Wrapper.m_Gameplay2_Grabbing;
        public InputAction @Title => m_Wrapper.m_Gameplay2_Title;
        public InputAction @Movement => m_Wrapper.m_Gameplay2_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay2Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay2Actions instance)
        {
            if (m_Wrapper.m_Gameplay2ActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
                @Launch.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLaunch;
                @Lights.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLights;
                @Lights.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLights;
                @Lights.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLights;
                @Music.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMusic;
                @Music.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMusic;
                @Music.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMusic;
                @Hide.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnHide;
                @Hide.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnHide;
                @Hide.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnHide;
                @Invis.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnInvis;
                @Invis.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnInvis;
                @Invis.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnInvis;
                @Appear.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnAppear;
                @Appear.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnAppear;
                @Appear.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnAppear;
                @Taking.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTaking;
                @Taking.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTaking;
                @Taking.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTaking;
                @Leaving.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLeaving;
                @Leaving.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLeaving;
                @Leaving.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnLeaving;
                @Grabbing.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnGrabbing;
                @Grabbing.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnGrabbing;
                @Grabbing.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnGrabbing;
                @Title.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTitle;
                @Title.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTitle;
                @Title.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTitle;
                @Movement.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_Gameplay2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
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
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public Gameplay2Actions @Gameplay2 => new Gameplay2Actions(this);
    public interface IGameplayActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnLights(InputAction.CallbackContext context);
        void OnMusic(InputAction.CallbackContext context);
        void OnHide(InputAction.CallbackContext context);
        void OnInvis(InputAction.CallbackContext context);
        void OnAppear(InputAction.CallbackContext context);
        void OnTaking(InputAction.CallbackContext context);
        void OnLeaving(InputAction.CallbackContext context);
        void OnGrabbing(InputAction.CallbackContext context);
        void OnTitle(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IGameplay1Actions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnLights(InputAction.CallbackContext context);
        void OnMusic(InputAction.CallbackContext context);
        void OnHide(InputAction.CallbackContext context);
        void OnInvis(InputAction.CallbackContext context);
        void OnAppear(InputAction.CallbackContext context);
        void OnTaking(InputAction.CallbackContext context);
        void OnLeaving(InputAction.CallbackContext context);
        void OnGrabbing(InputAction.CallbackContext context);
        void OnTitle(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IGameplay2Actions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnLights(InputAction.CallbackContext context);
        void OnMusic(InputAction.CallbackContext context);
        void OnHide(InputAction.CallbackContext context);
        void OnInvis(InputAction.CallbackContext context);
        void OnAppear(InputAction.CallbackContext context);
        void OnTaking(InputAction.CallbackContext context);
        void OnLeaving(InputAction.CallbackContext context);
        void OnGrabbing(InputAction.CallbackContext context);
        void OnTitle(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
