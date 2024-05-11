﻿using VisualInformationSystemDesigner.View.Device.Server;
using VisualInformationSystemDesigner.ViewModel.Device.Server;

namespace VisualInformationSystemDesigner.Model.Device.Server
{
    public class ServerModel : DeviceModel
    {
        /// <summary>
        /// Отобразить окно с информацией о сервере
        /// </summary>
        /// <param name="device">Ссылка на сервер</param>
        public override void ShowDeviceInformation(ref DeviceModel device)
        {
            var serverMethodsViewModel = new ServerMethodsViewModel(ref device);
            var serverMethodsView = new ServerMethodsView();
            serverMethodsView.DataContext = serverMethodsViewModel;
            serverMethodsView.Show();
        }
    }
}