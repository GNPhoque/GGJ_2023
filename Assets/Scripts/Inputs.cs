//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""90c7804c-de2e-42db-9cd9-4199c1e3b6aa"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""5d1adb9e-03e9-4ad0-9112-49bb0f476a1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""456f65c6-5854-4c8a-b2fb-3261dcba488e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeRootA"",
                    ""type"": ""Button"",
                    ""id"": ""8ba85eb7-76fc-40df-9cf7-f248282f041f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeRootE"",
                    ""type"": ""Button"",
                    ""id"": ""89650baa-63bf-43b2-8589-caf66822b35e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8148a5a8-2740-4968-9d6c-247d0465082e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9195d935-5580-41f0-8c4b-02dc4b1adb3a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c5e416e-11a1-4e10-a5d1-a4d7e3bae575"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeRootA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3336e7a-106d-401e-ae99-a32fdb1aa91f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeRootE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_MouseClick = m_Action.FindAction("MouseClick", throwIfNotFound: true);
        m_Action_MousePosition = m_Action.FindAction("MousePosition", throwIfNotFound: true);
        m_Action_ChangeRootA = m_Action.FindAction("ChangeRootA", throwIfNotFound: true);
        m_Action_ChangeRootE = m_Action.FindAction("ChangeRootE", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_MouseClick;
    private readonly InputAction m_Action_MousePosition;
    private readonly InputAction m_Action_ChangeRootA;
    private readonly InputAction m_Action_ChangeRootE;
    public struct ActionActions
    {
        private @Inputs m_Wrapper;
        public ActionActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_Action_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_Action_MousePosition;
        public InputAction @ChangeRootA => m_Wrapper.m_Action_ChangeRootA;
        public InputAction @ChangeRootE => m_Wrapper.m_Action_ChangeRootE;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MousePosition.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
                @ChangeRootA.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootA;
                @ChangeRootA.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootA;
                @ChangeRootA.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootA;
                @ChangeRootE.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootE;
                @ChangeRootE.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootE;
                @ChangeRootE.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnChangeRootE;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @ChangeRootA.started += instance.OnChangeRootA;
                @ChangeRootA.performed += instance.OnChangeRootA;
                @ChangeRootA.canceled += instance.OnChangeRootA;
                @ChangeRootE.started += instance.OnChangeRootE;
                @ChangeRootE.performed += instance.OnChangeRootE;
                @ChangeRootE.canceled += instance.OnChangeRootE;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IActionActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnChangeRootA(InputAction.CallbackContext context);
        void OnChangeRootE(InputAction.CallbackContext context);
    }
}
