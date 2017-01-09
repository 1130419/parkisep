using System;
using System.Collections.Generic;
using System.Linq;
using ParkIsepAPI.Models;
using ParkIsepAPI.Data;
using Microsoft.EntityFrameworkCore;
using ParkIsepAPI.Repository.Interfaces;

namespace ParkIsepAPI.Repository
{
    public class ParkRepository : IParkRepository
    {
        private ApplicationDbContext context;

        public ParkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Park> GetParks()
        {   
            return context.Parks.Include(x => x.Sensors).ToList();
        }

        public Park GetParkById(int id)
        {
            return context.Parks.Include(x => x.Sensors).SingleOrDefault(x => x.ID == id);
        }

        public Park InsertPark(Park park)
        {
            context.Parks.Add(park);
            Save();
            return park;
        }

        public void DeletePark(int parkId)
        {
            Park park = context.Parks.Find(parkId);
            context.Parks.Remove(park);
            Save();
        }

        public void UpdatePark(Park park)
        {
            Park parkToUpdate = context.Parks.Include(x => x.Sensors).SingleOrDefault(x => x.ID == park.ID);
            parkToUpdate.Name = park.Name;
            parkToUpdate.Sensors = park.Sensors;
            context.Update(parkToUpdate);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}