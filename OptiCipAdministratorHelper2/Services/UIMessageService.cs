using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAccessOnFramework.Models;
using OptiCipAdministratorHelper2.Services.UIServiceService;
using OptiCipAdministratorHelper2.Services.UIServiceService.ViewModel;

namespace OptiCipAdministratorHelper2.Services
{
    /// <summary>
    /// Класс запуска окон
    /// </summary>
    public class UIMessageService
    {
        IComponentContext _container;
        public UIMessageService(ILifetimeScope container)
        {
            _container = container;            
        }

        public bool ShowMessageListInfo(string message)
        {
            MessageListInfo messageListInfo = new MessageListInfo();
            MessageListInfoViewModel messageListInfoViewModel = new MessageListInfoViewModel(messageListInfo, message);
            messageListInfo.DataContext = messageListInfoViewModel;
            messageListInfo.ShowDialog();
            return messageListInfoViewModel.IsSuccess;            
        }

    }
}
