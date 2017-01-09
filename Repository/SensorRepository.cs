using System;
using System.Collections.Generic;
using System.Linq;
using ParkIsepAPI.Models;
using ParkIsepAPI.Data;
using Microsoft.EntityFrameworkCore;
using ParkIsepAPI.Repository.Interfaces;

namespace ParkIsepAPI.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private ApplicationDbContext context;

        public SensorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Sensor> GetSensors()
        {   
            return context.Sensors.ToList();
        }

        public Sensor GetSensorById(int id)
        {
            return context.Sensors.SingleOrDefault(x => x.ID == id);
        }

        public Sensor InsertSensor(Sensor sensor)
        {
            context.Sensors.Add(sensor);
            Save();
            return sensor;
        }

        public void DeleteSensor(int sensorId)
        {
            Sensor sensor = context.Sensors.Find(sensorId);
            context.Sensors.Remove(sensor);
            Save();
        }

        public void UpdateSensor(Sensor sensor)
        {
            Sensor sensorToUpdate = context.Sensors.SingleOrDefault(x => x.ID == sensor.ID);
            sensorToUpdate.Latitude = sensor.Latitude;
            sensorToUpdate.Longitude = sensor.Longitude;
            sensorToUpdate.Occupied = sensor.Occupied;
            context.Update(sensorToUpdate);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}