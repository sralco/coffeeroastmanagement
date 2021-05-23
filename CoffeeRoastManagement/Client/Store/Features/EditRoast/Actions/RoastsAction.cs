using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.Features.EditRoast.Actions
{
    public class RoastsInitializedAction { }

    public class RoastsLoadAction { }

    public class RoastsSetAction
    {
        public CoffeeRoastManagement.Shared.Entities.Roast[] Roasts { get; }

        public RoastsSetAction(CoffeeRoastManagement.Shared.Entities.Roast[] roasts)
        {
            Roasts = roasts;
        }
    }

    public class RoastsAddAction { }

    public class RoastsSetStocksAction
    {
        public CoffeeRoastManagement.Shared.Entities.Stock[] Stocks { get; }

        public RoastsSetStocksAction(CoffeeRoastManagement.Shared.Entities.Stock[] stocks)
        {
            Stocks = stocks;
        }
    }

    public class RoastsSetGreenBlendAction {
        public CoffeeRoastManagement.Shared.Entities.GreenBlend[] Blends { get; }
        public RoastsSetGreenBlendAction(CoffeeRoastManagement.Shared.Entities.GreenBlend[] blends)
        {
            Blends = blends;
        }
    }

    public class RoastsDateChangeAction { 
        public DateTime Date { get; }

        public RoastsDateChangeAction(DateTime date)
        {
            Date = date;
        }
    }

    public class RoastsTimeChangeAction
    {
        public TimeSpan Time { get; }

        public RoastsTimeChangeAction(TimeSpan time)
        {
            Time = time;
        }
    }

    public class RoastsPhotoChangeAction
    {
        public string Photo { get; }

        public RoastsPhotoChangeAction(string photo)
        {
            Photo = photo;
        }
    }

    public class RoastsRoastProfileChangeAction
    { 
        public string RoastProfile { get; }

        public RoastsRoastProfileChangeAction(string roastProfile)
        {
            RoastProfile = roastProfile;
        }
    }

    public class RoastsUpdateFieldsAction
    {
        public string RoastProfile { get; }

        public RoastsUpdateFieldsAction(string roastProfile)
        {
            RoastProfile = roastProfile;
        }
    }
    //public class ContactsDeleteAction
    //{
    //    public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

    //    public ContactsDeleteAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
    //    {
    //        Contact = contact;
    //    }
    //}

    //public class ContactDeleteSuccessAction { }

    //public class ContactDeleteFailureAction
    //{
    //    public string ErrorMessage { get; }
    //    public ContactDeleteFailureAction(string errorMessage)
    //    {
    //        ErrorMessage = errorMessage;
    //    }
    //}

    public class RoastsSaveRoastAction
    {
        public CoffeeRoastManagement.Shared.Entities.Roast Roast { get; }

        public RoastsSaveRoastAction(CoffeeRoastManagement.Shared.Entities.Roast roast)
        {
            Roast = roast;
        }
    }

    public class RoastCreateSuccessAction { }

    public class RoastCreateFailureAction
    {
        public string ErrorMessage { get; }
        public RoastCreateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class RoastUpdateSuccessAction { }

    public class RoastUpdateFailureAction
    {
        public string ErrorMessage { get; }
        public RoastUpdateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class RoastNameChangeAction
    {
        public string Name { get; }
        public RoastNameChangeAction(string name) { Name = name; }
    }

    public class RoastShortInfoChangeAction
    {
        public string ShortInfo { get; }
        public RoastShortInfoChangeAction(string shortInfo) { ShortInfo = shortInfo; }
    }

    public class RoastNoteChangeAction
    {
        public string Note { get; }
        public RoastNoteChangeAction(string note) { Note = note; }
    }

    public class RoastEquipmentChangeAction
    {
        public string Equipment { get; }
        public RoastEquipmentChangeAction(string equipment) { Equipment = equipment; }
    }

    public class RoastsRoastDeleteAction
    {
        public CoffeeRoastManagement.Shared.Entities.Roast Roast { get; }
        public RoastsRoastDeleteAction(CoffeeRoastManagement.Shared.Entities.Roast roast)
        {
            Roast = roast;
        }
    }

    public class RoastDeleteSuccessAction { }

    public class RoastDeleteFailureAction
    {
        public string ErrorMessage { get; }
        public RoastDeleteFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class RoastsRoastEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.Roast Roast { get; }
        public RoastsRoastEditAction(CoffeeRoastManagement.Shared.Entities.Roast roast)
        {
            Roast = roast;
        }
    }

    public class RoastsSetCurrentRoastAction
    {
        public int RoastId { get; }
        public RoastsSetCurrentRoastAction(int roastId)
        {
            RoastId = roastId;
        }

    }

}
