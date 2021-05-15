using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Actions
{
    public class GreenBeansInitializedAction { }
    public class GreenBeansLoadAction { }

    public class GreenBeansSetAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo[] GreenBeanInfos { get; }

        public GreenBeansSetAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo[] greenBeanInfos)
        {
            GreenBeanInfos = greenBeanInfos;
        }
    }

    public class GreenBeansDeleteAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }

        public GreenBeansDeleteAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBeanInfo)
        {
            GreenBeanInfo = greenBeanInfo;
        }
    }

    public class GreenBeansDeleteSuccessAction { }
    public class GreenBeansDeleteFailureAction
    {
        public string ErrorMessage { get; }
        public GreenBeansDeleteFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
    
    public class GreenBeansSaveAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }

        public GreenBeansSaveAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBeanInfo)
        {
            GreenBeanInfo = greenBeanInfo;
        }
    }

    public class GreenBeanCreateSuccessAction { }

    public class GreenBeanCreateFailureAction
    {
        public string ErrorMessage { get; }
        public GreenBeanCreateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class GreenBeanUpdateSuccessAction { }
    public class GreenBeanUpdateFailureAction
    {
        public string ErrorMessage { get; }
        public GreenBeanUpdateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
    public class GreenBeanSubmitAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }
        public GreenBeanSubmitAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBeanInfo)
        {
            GreenBeanInfo = greenBeanInfo;
        }
    }

    public class GreenBeanEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }

        public GreenBeanEditAction(CoffeeRoastManagement.Shared.Entities.GreenBeanInfo greenBeanInfo)
        {
            GreenBeanInfo = greenBeanInfo;
        }
    }

    public class GreenBeanStopEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.GreenBeanInfo GreenBeanInfo { get; }

        public GreenBeanStopEditAction()
        {
            GreenBeanInfo = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo();
        }
    }

    public class GreenBeanAddAction { }
}
