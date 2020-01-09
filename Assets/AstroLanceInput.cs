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
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightEngineOn"",
                    ""type"": ""Value"",
                    ""id"": ""e600b77b-3f44-4e98-bcb0-d9a35c4ffb27"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RepairLifeSupport"",
                    ""type"": ""Button"",
                    ""id"": ""bfef92a7-f599-47df-a559-61a44fa008cc"",
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
                    ""interactions"": ""Press(behavior=2)"",
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
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightEngineOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cf26945-cad6-4224-af17-65f16534bbaf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RepairLifeSupport"",
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
        m_PlayerActionMap_RightEngineOn = m_PlayerActionMap.FindAction("RightEngineOn", throwIfNotFound: true);
        m_PlayerActionMap_RepairLifeSupport = m_PlayerActionMap.FindAction("RepairLifeSupport", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerActionMap_RightEngineOn;
    private readonly InputAction m_PlayerActionMap_RepairLifeSupport;
    public struct PlayerActionMapActions
    {
        private @AstroLanceInput m_Wrapper;
        public PlayerActionMapActions(@AstroLanceInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftEngineOn => m_Wrapper.m_PlayerActionMap_LeftEngineOn;
        public InputAction @RightEngineOn => m_Wrapper.m_PlayerActionMap_RightEngineOn;
        public InputAction @RepairLifeSupport => m_Wrapper.m_PlayerActionMap_RepairLifeSupport;
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
                @RightEngineOn.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RightEngineOn.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RightEngineOn.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRightEngineOn;
                @RepairLifeSupport.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRepairLifeSupport;
                @RepairLifeSupport.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRepairLifeSupport;
                @RepairLifeSupport.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRepairLifeSupport;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftEngineOn.started += instance.OnLeftEngineOn;
                @LeftEngineOn.performed += instance.OnLeftEngineOn;
                @LeftEngineOn.canceled += instance.OnLeftEngineOn;
                @RightEngineOn.started += instance.OnRightEngineOn;
                @RightEngineOn.performed += instance.OnRightEngineOn;
                @RightEngineOn.canceled += instance.OnRightEngineOn;
                @RepairLifeSupport.started += instance.OnRepairLifeSupport;
                @RepairLifeSupport.performed += instance.OnRepairLifeSupport;
                @RepairLifeSupport.canceled += instance.OnRepairLifeSupport;
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
        void OnRightEngineOn(InputAction.CallbackContext context);
        void OnRepairLifeSupport(InputAction.CallbackContext context);
    }
}
