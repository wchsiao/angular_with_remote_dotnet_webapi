using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class ColdRoomTemperature
{
    public long ColdRoomTemperatureId { get; set; }

    public int ColdRoomSensorNumber { get; set; }

    public DateTime RecordedWhen { get; set; }

    public decimal Temperature { get; set; }
}
