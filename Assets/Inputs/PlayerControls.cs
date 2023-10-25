//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Inputs/PlayerControlsMap.inputactions
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

namespace PlayerControlScript
{
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlsMap"",
    ""maps"": [
        {
            ""name"": ""LinkControls"",
            ""id"": ""226e59d3-25ae-482d-a4fb-edc637e9a338"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""675ab377-5433-4602-9829-c79ecc2a882e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""967d327a-baff-46e1-a83b-137c0a2da191"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a3f72696-3a32-4242-bef6-008581558415"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""29d57c2c-91c6-4285-bb50-07b7b36dd70a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e8195f71-7e5f-416b-9da4-9d9e0fe5d92c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""780c4b86-afad-4386-98b0-f3cb643a968a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""bd4d6bdd-a4b7-4740-a9f8-cd728ca1282f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Loading"",
                    ""type"": ""Button"",
                    ""id"": ""47447301-6a2e-4fa1-bfd6-e30445e3a797"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""4489c52c-a32f-4f71-87cd-648878a62ff2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchExit"",
                    ""type"": ""Button"",
                    ""id"": ""0360671f-dba7-406b-9c7c-e6b20eacd1f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0d2c4db-d36d-4b1a-8b2a-cc5b4645c40b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6ca8fbc-0404-4e23-8965-1c7d553252a6"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""096fb336-9e8c-4297-bba2-253e39f8bb92"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""adecb37b-836d-46be-ad48-3d728b72b38b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d793376-76ba-4f7f-a3b0-9fd8e8c9a2aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dd7b0634-ad3e-4d80-8631-76f94975fca7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""05d5eca0-9c99-4af5-b7af-2ed886d2b9d6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cdf3c07a-8940-4881-a062-79c2d3b6e4d2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20b04490-e205-4ced-873d-9e4157a70975"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5641a414-89fd-4b18-bd0a-fde7bb95e18e"",
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
                    ""id"": ""c594bdf1-fbee-45af-89e8-66437c68de0e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b0dff5-d4a4-4003-8c81-af3a98b2a20e"",
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
                    ""id"": ""0aa4e735-98b7-4170-99e0-f11a545fd6a6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""329d362a-604a-41cf-88a8-0e9f0d04490d"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb895533-9de0-4c4e-8800-6df8466b51ac"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c5e1fa1-a4e4-4ec9-9c5e-d4a33e861bfc"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aecc90ab-e872-4432-bef8-fe14df794643"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cc7fdac-96fc-4d34-9628-50a54657e851"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de5733e4-7f81-4d3f-bd9b-b46ad8edbe9e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Loading"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a016d42-e143-49d3-8d92-b6c402b0816f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Loading"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0cc6b48-1e6c-4e46-a00c-775aff2ff49c"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57fdd451-8a21-4d00-8650-928cb03ee82e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6caca899-d7ad-41ea-8ee6-9f1360cbcb58"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45e658c3-59b4-468e-8385-3d247bb87792"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // LinkControls
            m_LinkControls = asset.FindActionMap("LinkControls", throwIfNotFound: true);
            m_LinkControls_Move = m_LinkControls.FindAction("Move", throwIfNotFound: true);
            m_LinkControls_Jump = m_LinkControls.FindAction("Jump", throwIfNotFound: true);
            m_LinkControls_Sprint = m_LinkControls.FindAction("Sprint", throwIfNotFound: true);
            m_LinkControls_Camera = m_LinkControls.FindAction("Camera", throwIfNotFound: true);
            m_LinkControls_Attack = m_LinkControls.FindAction("Attack", throwIfNotFound: true);
            m_LinkControls_Glide = m_LinkControls.FindAction("Glide", throwIfNotFound: true);
            m_LinkControls_Shoot = m_LinkControls.FindAction("Shoot", throwIfNotFound: true);
            m_LinkControls_Loading = m_LinkControls.FindAction("Loading", throwIfNotFound: true);
            m_LinkControls_TouchPress = m_LinkControls.FindAction("TouchPress", throwIfNotFound: true);
            m_LinkControls_TouchExit = m_LinkControls.FindAction("TouchExit", throwIfNotFound: true);
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

        // LinkControls
        private readonly InputActionMap m_LinkControls;
        private List<ILinkControlsActions> m_LinkControlsActionsCallbackInterfaces = new List<ILinkControlsActions>();
        private readonly InputAction m_LinkControls_Move;
        private readonly InputAction m_LinkControls_Jump;
        private readonly InputAction m_LinkControls_Sprint;
        private readonly InputAction m_LinkControls_Camera;
        private readonly InputAction m_LinkControls_Attack;
        private readonly InputAction m_LinkControls_Glide;
        private readonly InputAction m_LinkControls_Shoot;
        private readonly InputAction m_LinkControls_Loading;
        private readonly InputAction m_LinkControls_TouchPress;
        private readonly InputAction m_LinkControls_TouchExit;
        public struct LinkControlsActions
        {
            private @PlayerControls m_Wrapper;
            public LinkControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_LinkControls_Move;
            public InputAction @Jump => m_Wrapper.m_LinkControls_Jump;
            public InputAction @Sprint => m_Wrapper.m_LinkControls_Sprint;
            public InputAction @Camera => m_Wrapper.m_LinkControls_Camera;
            public InputAction @Attack => m_Wrapper.m_LinkControls_Attack;
            public InputAction @Glide => m_Wrapper.m_LinkControls_Glide;
            public InputAction @Shoot => m_Wrapper.m_LinkControls_Shoot;
            public InputAction @Loading => m_Wrapper.m_LinkControls_Loading;
            public InputAction @TouchPress => m_Wrapper.m_LinkControls_TouchPress;
            public InputAction @TouchExit => m_Wrapper.m_LinkControls_TouchExit;
            public InputActionMap Get() { return m_Wrapper.m_LinkControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LinkControlsActions set) { return set.Get(); }
            public void AddCallbacks(ILinkControlsActions instance)
            {
                if (instance == null || m_Wrapper.m_LinkControlsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LinkControlsActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Loading.started += instance.OnLoading;
                @Loading.performed += instance.OnLoading;
                @Loading.canceled += instance.OnLoading;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchExit.started += instance.OnTouchExit;
                @TouchExit.performed += instance.OnTouchExit;
                @TouchExit.canceled += instance.OnTouchExit;
            }

            private void UnregisterCallbacks(ILinkControlsActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Camera.started -= instance.OnCamera;
                @Camera.performed -= instance.OnCamera;
                @Camera.canceled -= instance.OnCamera;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Glide.started -= instance.OnGlide;
                @Glide.performed -= instance.OnGlide;
                @Glide.canceled -= instance.OnGlide;
                @Shoot.started -= instance.OnShoot;
                @Shoot.performed -= instance.OnShoot;
                @Shoot.canceled -= instance.OnShoot;
                @Loading.started -= instance.OnLoading;
                @Loading.performed -= instance.OnLoading;
                @Loading.canceled -= instance.OnLoading;
                @TouchPress.started -= instance.OnTouchPress;
                @TouchPress.performed -= instance.OnTouchPress;
                @TouchPress.canceled -= instance.OnTouchPress;
                @TouchExit.started -= instance.OnTouchExit;
                @TouchExit.performed -= instance.OnTouchExit;
                @TouchExit.canceled -= instance.OnTouchExit;
            }

            public void RemoveCallbacks(ILinkControlsActions instance)
            {
                if (m_Wrapper.m_LinkControlsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILinkControlsActions instance)
            {
                foreach (var item in m_Wrapper.m_LinkControlsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LinkControlsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LinkControlsActions @LinkControls => new LinkControlsActions(this);
        public interface ILinkControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnCamera(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnGlide(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnLoading(InputAction.CallbackContext context);
            void OnTouchPress(InputAction.CallbackContext context);
            void OnTouchExit(InputAction.CallbackContext context);
        }
    }
}
