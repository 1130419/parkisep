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
    public class ParksController : Controller
    {
        private IParkRepository parkRepository;

        public ParksController(ApplicationDbContext context)
        {
            this.parkRepository = new ParkRepository(context);
        }

        // GET api/Parks
        [HttpGet]
        public IEnumerable<Park> Get()
        {
            return this.parkRepository.GetParks();
        }

        // GET api/Parks/5
        [HttpGet("{id}")]
        public Park Get(int id)
        {
           return this.parkRepository.GetParkById(id);
        }

        // POST api/Parks
        [HttpPost]
        public Park Post([FromBody]Park park)
        {
            return this.parkRepository.InsertPark(park);
        }

        // PUT api/Parks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Park park)
        {
            park.ID = id;
            this.parkRepository.UpdatePark(park);
        }

        // DELETE api/Parks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.parkRepository.DeletePark(id);
        }

        // GET api/Parks/allSensors/5
        [HttpGet]
        [Route("allSensors/{parkId}")]
        public ICollection<Sensor> GetParkSensors(int parkId)
        {
            Park park = this.parkRepository.GetParkById(parkId);
            return park.GetSensors();
        }
        
        // GET api/Parks/occupationPercentage/5
        [HttpGet]
        [Route("occupationPercentage/{parkId}")]
        public double GetParkOccuptionPercentage(int parkId)
        {
            Park park = this.parkRepository.GetParkById(parkId);
            return park.GetOccupationPercentage();
        }

        // GET api/Parks/occupiedSensors/5
        [HttpGet]
        [Route("occupiedSensors/{parkId}")]
        public ICollection<Sensor> GetParkOccupiedSensors(int parkId)
        {
            Park park = this.parkRepository.GetParkById(parkId);
            return park.GetOccupiedSensors();
        }

        // GET api/Parks/freeSensors/5
        [HttpGet]
        [Route("freeSensors/{parkId}")]
        public ICollection<Sensor> GetParkFreeSensors(int parkId)
        {
            Park park = this.parkRepository.GetParkById(parkId);
            return park.GetFreeSensors();
        }
    }
}
