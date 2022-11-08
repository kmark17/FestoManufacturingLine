using FestoManufacturingLine_ModBus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class DistributingStationViewModel : ViewModelBase
    {
        public ObservableCollection<DistributingStationModBusVariable> DistributingStationModBusVariables { get; } = new ObservableCollection<DistributingStationModBusVariable>();

        public DistributingStationViewModel()
        {
            // Initializing DataGrid ItemsSource
            {
                DistributingStationModBusVariables!.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixCylinderRetracted_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixCylinderEjected_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixVacuumSensor_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixLeftPosition_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixRightPosition_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixMagazineEmpty_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixNextStationIsFree_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxEjectWorkpiece_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxVacuumOn_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxVacuumOff_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxRotateLeft_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxRotateRight_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxUIState_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });
            }
        }
    }
}
