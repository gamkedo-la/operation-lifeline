// GENERATED AUTOMATICALLY FROM 'Assets/AstroLanceInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AstroLanceInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @AstroLanceInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AstroLanceInput"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""1d575525-4401-4d16-98db-c0d7fc36ce3c"",
            ""actions"": [
                {
                    ""name"": ""LeftEngineOn"",
                    ""type"": ""Value"",
                    ""id"": ""e8bc622a-86f4-46ae-b5c9-dd2359e314f7"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftEngineOff"",
                    ""type"": ""Button"",
                    ""id"": ""57d41185-573c-46a4-a87c-29660b9d6fc4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightEngineOn"",
                    ""type"": ""Button"",
                    ""id"": ""e600b77b-3f44-4e98-bcb0-d9a35c4ffb27"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightEngineOff"",
                    ""type"": ""Button"",
                    ""id"": ""e8fa5909-c5f9-40e3-9e18-4e77703c16c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2554bab-3504-4970-af50-c0a10a35c726"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftEngineOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbcddf6-332d-44cb-ac17-e122fb5c14b7"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": ""Hold(duration=0.01)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightEngineOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33f89095-80c0-4807-b1e8-88fe495304af"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftEngineOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97a24f91-975d-46c7-ad08-d715103a972c"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightEngineOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_LeftEngineOn = m_PlayerActionMap.FindAction("LeftEngineOn", throwIfNotFound: true);
        m_PlayerActionMap_LeftEngineOff = m_PlayerActionMap.FindAction("LeftEngineOff", throwIfNotFound: true);
        m_PlayerActionMap_RightEngineOn = m_PlayerActionMap.FindAction("RightEngineOn", throwIfNotFound: true);
        m_PlayerActionMap_RightEngineOff = m_PlayerActionMap.FindAction("RightEngineOff", throwIfNotFound: true);
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

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerActionMap_LeftEngineOn;
    private readonly InputAction m_PlayerActionMap_LeftEngineOff;
    private readonly InputAction m_PlayerActionMap_RightEngineOn;
    private readonly InputAction m_PlayerActionMap_RightEngineOff;
    public struct PlayerActionMapActions
    {
        private @AstroLanceInput m_Wrapper;
        public PlayerActionMapActions(@AstroLanceInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftEngineOn => m_Wrapper.m_PlayerActionMap_LeftEngineOn;
        public InputAction @LeftEngineOff => m_Wrapper.m_PlayerActionMap_LeftEngineOff;
        public InputAction @RightEngineOn => m_Wrapper.m_PlayerActionMap_RightEngineOn;
        public InputAction @RightEngineOff => m_Wrapper.m_PlayerActionMap_RightEngineOff;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @LeftEngineOn.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOn;
                @LeftEngineOn.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOn;
                @LeftEngineOn.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOn;
                @LeftEngineOff.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOff;
                @LeftEngineOff.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOff;
                @LeftEngineOff.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLeftEngineOff;
                @RightEngineOn.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RightEngineOn.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RightEngineOn.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RightEngineOff.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOff;
                @RightEngineOff.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOff;
                @RightEngineOff.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOff;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftEngineOn.started += instance.OnLeftEngineOn;
                @LeftEngineOn.performed += instance.OnLeftEngineOn;
                @LeftEngineOn.canceled += instance.OnLeftEngineOn;
                @LeftEngineOff.started += instance.OnLeftEngineOff;
                @LeftEngineOff.performed += instance.OnLeftEngineOff;
                @LeftEngineOff.canceled += instance.OnLeftEngineOff;
                @RightEngineOn.started += instance.OnRightEngineOn;
                @RightEngineOn.performed += instance.OnRightEngineOn;
                @RightEngineOn.canceled += instance.OnRightEngineOn;
                @RightEngineOff.started += instance.OnRightEngineOff;
                @RightEngineOff.performed += instance.OnRightEngineOff;
                @RightEngineOff.canceled += instance.OnRightEngineOff;
            }
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActionMapActions
    {
        void OnLeftEngineOn(InputAction.CallbackContext context);
        void OnLeftEngineOff(InputAction.CallbackContext context);
        void OnRightEngineOn(InputAction.CallbackContext context);
        void OnRightEngineOff(InputAction.CallbackContext context);
    }
}
