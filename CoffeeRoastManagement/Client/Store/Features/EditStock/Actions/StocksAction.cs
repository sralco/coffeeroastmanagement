using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.Features.EditStock.Actions
{
    public class StocksInitializedAction { }
    public class StocksLoadAction { }

    public class StocksSetAction
    {
        public CoffeeRoastManagement.Shared.Entities.Stock[] Stocks { get; }

        public StocksSetAction(CoffeeRoastManagement.Shared.Entities.Stock[] stocks)
        {
            Stocks = stocks;
        }
    }

    public class SelectedGreenBeanChangeAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }

        public SelectedGreenBeanChangeAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBeanInfo)
        {
            GreenBeanInfo = greenBeanInfo;
        }
    }
    public class StocksGreenBeansLoadAction { }

    public class StockDeleteAction
    {
        public CoffeeRoastManagement.Shared.Entities.Stock Stock { get; }

        public StockDeleteAction(CoffeeRoastManagement.Shared.Entities.Stock stock)
        {
            Stock = stock;
        }
    }

    public class StockDeleteSuccessAction { }
    public class StockDeleteFailureAction
    {
        public string ErrorMessage { get; }
        public StockDeleteFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class StocksGreenBeanSaveAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBean { get; }

        public StocksGreenBeanSaveAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBean)
        {
            GreenBean = greenBean;
        }
    }

    public class StockSaveAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBean { get; }
        public CoffeeRoastManagement.Shared.Entities.Stock Stock { get; }

        public StockSaveAction(CoffeeRoastManagement.Shared.Entities.Contact contact, CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBean, CoffeeRoastManagement.Shared.Entities.Stock stock)
        {
            Contact = contact;
            GreenBean = greenBean;
            Stock = stock;
        }
    }

    public class StockSaveActionSecond
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBean { get; }
        public CoffeeRoastManagement.Shared.Entities.Stock Stock { get; }

        public StockSaveActionSecond(CoffeeRoastManagement.Shared.Entities.Contact contact, CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBean, CoffeeRoastManagement.Shared.Entities.Stock stock)
        {
            Contact = contact;
            GreenBean = greenBean;
            Stock = stock;

        }
    }

    public class SetSelectedContactAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }
        public SetSelectedContactAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }

    public class StockCreateSuccessAction { }

    public class StockCreateFailureAction
    {
        public string ErrorMessage { get; }
        public StockCreateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class StockUpdateSuccessAction { }
    
    public class StockUpdateFailureAction
    {
        public string ErrorMessage { get; }
        public StockUpdateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
   
    public class StockSubmitAction
    {
        //public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }
        public StockSubmitAction(/*CoffeeRoastManagement.Shared.Entities.Contact contact*/)
        {
            //Contact = contact;
        }
    }

    public class StockEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.Stock Stock { get; }

        public StockEditAction(CoffeeRoastManagement.Shared.Entities.Stock stock)
        {
            Stock = stock;
        }
    }

    //public class ContactStopEditAction
    //{
    //    public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

    //    public ContactStopEditAction()
    //    {
    //        Contact = new CoffeeRoastManagement.Shared.Entities.Contact();
    //    }
    //}

    public class StocksAddAction { }
}
