using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditRoast.Actions;
using CoffeeRoastManagement.Client.Store.State;
using CoffeeRoastManagement.Shared.DataModel;
using Newtonsoft.Json;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.Features.EditRoast.Reducers
{
    public static class RoastsReducers
    {
        [ReducerMethod]
        public static RoastsState OnRoastsSet(RoastsState state, RoastsSetAction action)
        {
            return state with
            {
                Roasts = action.Roasts,
            };
        }
        
        [ReducerMethod]
        public static RoastsState OnRoastGreenBeanInfoSet(RoastsState state, RoastsSetStocksAction action)
        {
            return state with
            {
                Stocks = action.Stocks,
            };
        }

        [ReducerMethod(typeof(RoastsInitializedAction))]
        public static RoastsState OnRoastsInitialized(RoastsState state)
        {
            return state with
            {
                Initialized = true,
                Loading = false
            };
        }

        [ReducerMethod(typeof(RoastsLoadAction))]
        public static RoastsState OnRoastsLoad(RoastsState state)
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static RoastsState OnGreenBlendChange(RoastsState state, RoastsSetGreenBlendAction action)
        {
            return state with
            {
                GreenBlends = action.Blends,
            };
        }

        [ReducerMethod]
        public static RoastsState OnRoastDateChange(RoastsState state, RoastsDateChangeAction action)
        {
            return state with
            {
                Date = action.Date
            };
        }

        [ReducerMethod]
        public static RoastsState OnRoastTimeChange(RoastsState state, RoastsTimeChangeAction action)
        {
            return state with
            {
                Time = action.Time
            };
        }

        [ReducerMethod]
        public static RoastsState OnRoastPhotoChange(RoastsState state, RoastsPhotoChangeAction action)
        {
            return state with
            {
                Photo = action.Photo
            };
        }

        [ReducerMethod]
        public static RoastsState OnRoastProfileChange(RoastsState state, RoastsRoastProfileChangeAction action)
        {
            return state with
            {
                RoastProfile = action.RoastProfile
            };
        }

        //public static RoastsState OnRoastNameChange(RoastsState state, )
        [ReducerMethod]
        public static RoastsState OnUpdateFields(RoastsState state, RoastsUpdateFieldsAction action)
        {
            ArtisanFile artisan = JsonConvert.DeserializeObject<ArtisanFile>(action.RoastProfile);
            var newstate = state with {
                Equipment = artisan.RoasterType,
                Date = DateTimeOffset.FromUnixTimeSeconds(artisan.RoastEpoch + artisan.RoastTZOffset).DateTime.Date,
                Time = DateTimeOffset.FromUnixTimeSeconds(artisan.RoastEpoch + artisan.RoastTZOffset).Date.TimeOfDay
            };
            return newstate;
        }

        [ReducerMethod]
        public static RoastsState OnNameChange(RoastsState state, RoastNameChangeAction action)
        {
            return state with
            {
                Name = action.Name,
            };
        }

        [ReducerMethod]
        public static RoastsState OnShortInfoChange(RoastsState state, RoastShortInfoChangeAction action)
        {
            return state with
            {
                ShortInfo = action.ShortInfo,
            };
        }

        [ReducerMethod]
        public static RoastsState OnNoteChange(RoastsState state, RoastNoteChangeAction action)
        {
            return state with
            {
                Note = action.Note
            };
        }

        [ReducerMethod]
        public static RoastsState OnEquipmentChange(RoastsState state, RoastEquipmentChangeAction action)
        {
            return state with
            {
                Equipment = action.Equipment
            };
        }
 
        [ReducerMethod]
        public static RoastsState OnSaveRoast(RoastsState state, RoastsSaveRoastAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = true,
                CurrentRoast = new CoffeeRoastManagement.Shared.Entities.Roast(),
                RoastButtonText = "Create",
                ShowInputDialog = false,
                RoastEditMode = false,
                Name = string.Empty,
                ShortInfo = string.Empty,
                Note = string.Empty,
                GreenBlends = Array.Empty<CoffeeRoastManagement.Shared.Entities.GreenBlend>(),
                Date = null,
                Time = null,
                Equipment = string.Empty,
                ErrorMessage = string.Empty,
                Photo = string.Empty,
                RoastProfile = string.Empty,
            };
        }

        [ReducerMethod]
        public static RoastsState OnEditRoast(RoastsState state, RoastsRoastEditAction action)
        {
            return state with
            {
                RoastEditMode = true,
                RoastButtonText = "Update",
                ShowInputDialog = true,
                CurrentRoast = action.Roast,
                Date = action.Roast.Date.Date,
                Time = action.Roast.Date.TimeOfDay,
                Equipment = action.Roast.Equipment,
                GreenBlends = action.Roast.Beans.ToArray(),
                Name = action.Roast.Name,
                ShortInfo = action.Roast.ShortInfo,
                Photo = action.Roast.Photo,
                RoastProfile = action.Roast.RoastProfile,
                Note = action.Roast.Note,
                ErrorMessage = string.Empty
            };
        }

        [ReducerMethod(typeof(RoastsAddAction))]
        public static RoastsState OnRoastsAdd(RoastsState state)
        {
            // handle all cases, the last return statement handles the default case
            if (state.ShowInputDialog && state.RoastEditMode)
            {
                // we reset everything
                return state with
                {
                    ShowInputDialog = true,
                    RoastEditMode = false,
                    CurrentRoast = new CoffeeRoastManagement.Shared.Entities.Roast(),
                    Name = "",
                    ShortInfo = "",
                    Note = "",
                    Equipment = "",
                    ErrorMessage = "",
                    GreenBlends = Array.Empty<GreenBlend>(),
                    Date = null,
                    Photo = "",
                    RoastProfile = "",
                    Time = null,
                    RoastButtonText = "Create"
                };
            }
            if (state.ShowInputDialog && !state.RoastEditMode)
            {
                if (!string.IsNullOrEmpty(state.CurrentRoast.Name) || !string.IsNullOrEmpty(state.CurrentRoast.Note) || !string.IsNullOrEmpty(state.CurrentRoast.ShortInfo) || !string.IsNullOrEmpty(state.CurrentRoast.RoastProfile) || !string.IsNullOrEmpty(state.CurrentRoast.Photo))
                {
                    return state with
                    {
                        CurrentRoast = new CoffeeRoastManagement.Shared.Entities.Roast(),
                        Name = "",
                        ShortInfo = "",
                        Note = "",
                        Equipment= "",
                        ErrorMessage = "",
                        GreenBlends = Array.Empty<GreenBlend>(),
                        Date = null,
                        Photo ="",
                        RoastProfile = "",
                        Time = null,
                        
                        RoastButtonText = "Create",
                    };
                }
                else
                {
                    return state with
                    {
                        CurrentRoast = new CoffeeRoastManagement.Shared.Entities.Roast(),
                        Name = "",
                        ShortInfo = "",
                        Note = "",
                        Equipment = "",
                        ErrorMessage = "",
                        GreenBlends = Array.Empty<GreenBlend>(),
                        Date = null,
                        Photo = "",
                        RoastProfile = "",
                        Time = null,
                        RoastButtonText = "Create",
                        ShowInputDialog = false,
                    };
                }
            }
            return state with
            {
                ShowInputDialog = true,
            };
        }

        [ReducerMethod]
        public static RoastsState OnSetCurrentRoast(RoastsState state, RoastsSetCurrentRoastAction action)
        {
            return state with
            {
                CurrentRoast = state.Roasts.FirstOrDefault(x => x.Id == action.RoastId)
            };
        }
    }
}
