using System;
using System.Collections.Generic;
using ParkIsepAPI.Models;

namespace ParkIsepAPI.Repository.Interfaces
{
    public interface ISensorRepository
    {
        IEnumerable<Sensor> GetSensors();
        Sensor GetSensorById(int sensorId);
        Sensor InsertSensor(Sensor sensor);
        void DeleteSensor(int sensorId);
        void UpdateSensor(Sensor sensor);
        void Save();
    }
}