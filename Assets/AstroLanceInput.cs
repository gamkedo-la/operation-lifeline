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
            ""name"": ""Player"",
            ""id"": ""1d575525-4401-4d16-98db-c0d7fc36ce3c"",
            ""actions"": [
                {
                    ""name"": ""LeftEngine"",
                    ""type"": ""Button"",
                    ""id"": ""e8bc622a-86f4-46ae-b5c9-dd2359e314f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightEngine"",
                    ""type"": ""Button"",
                    ""id"": ""e600b77b-3f44-4e98-bcb0-d9a35c4ffb27"",
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
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftEngine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbcddf6-332d-44cb-ac17-e122fb5c14b7"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightEngine"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftEngine = m_Player.FindAction("LeftEngine", throwIfNotFound: true);
        m_Player_RightEngine = m_Player.FindAction("RightEngine", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftEngine;
    private readonly InputAction m_Player_RightEngine;
    public struct PlayerActions
    {
        private @AstroLanceInput m_Wrapper;
        public PlayerActions(@AstroLanceInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftEngine => m_Wrapper.m_Player_LeftEngine;
        public InputAction @RightEngine => m_Wrapper.m_Player_RightEngine;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftEngine.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftEngine;
                @LeftEngine.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftEngine;
                @LeftEngine.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftEngine;
                @RightEngine.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightEngine;
                @RightEngine.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightEngine;
                @RightEngine.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightEngine;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftEngine.started += instance.OnLeftEngine;
                @LeftEngine.performed += instance.OnLeftEngine;
                @LeftEngine.canceled += instance.OnLeftEngine;
                @RightEngine.started += instance.OnRightEngine;
                @RightEngine.performed += instance.OnRightEngine;
                @RightEngine.canceled += instance.OnRightEngine;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLeftEngine(InputAction.CallbackContext context);
        void OnRightEngine(InputAction.CallbackContext context);
    }
}
