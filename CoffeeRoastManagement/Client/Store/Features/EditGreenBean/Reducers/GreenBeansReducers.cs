using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Actions;
using CoffeeRoastManagement.Client.Store.State;

namespace CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Reducers
{
    public static class GreenBeansReducers
    {
        [ReducerMethod]
        public static GreenBeansState OnContactsSet(GreenBeansState state, GreenBeansSetAction action)
        {
            return state with
            {
                GreenBeans = action.GreenBeanInfos,
                Loading = false
            };
        }
        
        [ReducerMethod(typeof(GreenBeansInitializedAction))]
        public static GreenBeansState OnContactsInitialized(GreenBeansState state)
        {
            return state with
            {
                Initialized = true
            };
        }

        [ReducerMethod(typeof(GreenBeansLoadAction))]
        public static GreenBeansState OnContactsLoad(GreenBeansState state)
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnContactsDelete(GreenBeansState state, GreenBeansDeleteAction action)
        {
            if (state.CurrentGreenBean.Id == action.GreenBeanInfo.Id)
            {
                return state with
                {
                    CurrentGreenBean = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                    GreenBeanButtonText = "Create"
                };
            }
            return state with
            {
                
            };
        }

        [ReducerMethod(typeof(GreenBeanSubmitAction))]
        
        public static GreenBeansState OnSubmit(GreenBeansState state)
        {
            return state with
            {
                Submitting = true
            };
        }

        [ReducerMethod(typeof(GreenBeanCreateSuccessAction))]
        public static GreenBeansState OnCreateSuccess(GreenBeansState state)
        {
            return state with
            {
                Submitting = false,
                Submitted = true
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnCreateFailure(GreenBeansState state, GreenBeanCreateFailureAction action)
        {
            return state with
            {
                Submitting = false,
                ErrorMessage = action.ErrorMessage
            };
        }

        [ReducerMethod(typeof(GreenBeanUpdateSuccessAction))]
        public static GreenBeansState OnUpdateSuccess(GreenBeansState state)
        {
            return state with
            {
                Submitting = false,
                Submitted = true
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnUpdateFailure(GreenBeansState state, GreenBeanUpdateFailureAction action)
        {
            return state with
            {
                Submitting = false,
                ErrorMessage = action.ErrorMessage
            };
        }



        [ReducerMethod]
        public static GreenBeansState OnEditContact(GreenBeansState state, GreenBeanEditAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = false,
                ShowInputDialog = true,
                CurrentGreenBean = action.GreenBeanInfo,
                GreenBeanButtonText = "Update"
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnSaveContact(GreenBeansState state, GreenBeansSaveAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = true,
                CurrentGreenBean = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                GreenBeanButtonText = "Create",
                ShowInputDialog = false,
                GreenBeanEditMode = false
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnStopEditContact(GreenBeansState state, GreenBeanStopEditAction action)
        {
            return state with
            {
                CurrentGreenBean = action.GreenBeanInfo,
                GreenBeanButtonText = "Create",
            };
        }

        [ReducerMethod]
        public static GreenBeansState OnAddContact(GreenBeansState state, GreenBeanAddAction action)
        {
            // handle all cases, the last return statement handles the default case
            if (state.ShowInputDialog && state.GreenBeanEditMode)
            {
                // we reset everything
                return state with
                {
                    ShowInputDialog = true,
                    GreenBeanEditMode = false,
                    CurrentGreenBean = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                    GreenBeanButtonText = "Create"
                };
            }
            if (state.ShowInputDialog && !state.GreenBeanEditMode)
            {
                if (!string.IsNullOrEmpty(state.CurrentGreenBean.Name) 
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Note) 
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Url)
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Country)
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Farmer)
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Processing)
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Region)
                    || !string.IsNullOrEmpty(state.CurrentGreenBean.Variety)
                    || state.CurrentGreenBean.Crop != 0
                    || state.CurrentGreenBean.OverallCuppingScore != 0
                    )
                {
                    return state with
                    {
                        CurrentGreenBean = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                        GreenBeanButtonText = "Create",
                    };
                }else
                {
                    return state with
                    {
                        CurrentGreenBean = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                        GreenBeanButtonText = "Create",
                        ShowInputDialog = false,
                    };
                }
            }
            return state with
            {
                ShowInputDialog = true,
            };
        }
    }
}
