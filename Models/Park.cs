using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkIsepAPI.Models
{
    public class Park
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name {get;set;}
        public ICollection<Sensor> Sensors {get;set;}

        public ICollection<Sensor> GetSensors()
        {
            return this.Sensors;
        }

        public double GetOccupationPercentage()
        {
            double sensorsOccupied = 0;
            foreach (Sensor sensor in this.Sensors)
            {
                if (sensor.Occupied)
                {
                    sensorsOccupied++;
                }
            }
            return (sensorsOccupied / this.Sensors.Count) * 100;
        }

        public ICollection<Sensor> GetOccupiedSensors()
        {
            List<Sensor> occupiedSensors = new List<Sensor>();
            foreach (Sensor sensor in this.Sensors)
            {
                if (sensor.Occupied)
                {
                    occupiedSensors.Add(sensor);
                }
            }
            return occupiedSensors;
        }

        public ICollection<Sensor> GetFreeSensors()
        {
            List<Sensor> freeSensors = new List<Sensor>();
            foreach (Sensor sensor in this.Sensors)
            {
                if (!sensor.Occupied)
                {
                    freeSensors.Add(sensor);
                }
            }
            return freeSensors;
        }
    }
}