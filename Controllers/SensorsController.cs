using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using ParkIsepAPI.Models;
using ParkIsepAPI.Repository;
using ParkIsepAPI.Repository.Interfaces;
using ParkIsepAPI.Data;

namespace ParkIsepAPI.Controllers
{
    [Route("api/[controller]")]
    public class SensorsController : Controller
    {
        private ISensorRepository sensorRepository;

        public SensorsController(ApplicationDbContext context)
        {
            this.sensorRepository = new SensorRepository(context);
        }

        // GET api/sensors
        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return this.sensorRepository.GetSensors();
        }

        // GET api/sensors/5
        [HttpGet("{id}")]
        public Sensor Get(int id)
        {
           return this.sensorRepository.GetSensorById(id);
        }

        // POST api/sensors
        [HttpPost]
        public Sensor Post([FromBody]Sensor sensor)
        {
            return this.sensorRepository.InsertSensor(sensor);
        }

        // PUT api/sensors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Sensor sensor)
        {
            sensor.ID = id;
            this.sensorRepository.UpdateSensor(sensor);
        }

        // DELETE api/sensors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.sensorRepository.DeleteSensor(id);
        }
    }
}
