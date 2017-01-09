using System;
using System.Collections.Generic;
using ParkIsepAPI.Models;

namespace ParkIsepAPI.Repository.Interfaces
{
    public interface IParkRepository
    {
        IEnumerable<Park> GetParks();
        Park GetParkById(int parkId);
        Park InsertPark(Park park);
        void DeletePark(int parkId);
        void UpdatePark(Park park);
        void Save();
    }
}