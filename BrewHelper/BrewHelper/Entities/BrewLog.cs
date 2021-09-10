using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewHelper.Entities
{
    public class BrewLog
    {
        public BrewLog()
        {
            Notes = string.Empty;
        }
        
        public long Id { get; set; }
        /// <summary>
        /// Recipe the brewing is based off
        /// </summary>
        [Required]
        public Recipe Recipe { get; set; } = null!;

        /// <summary>
        /// Brewing notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Date the brewing started
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Date the brewing was completed
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Measured start SG
        /// </summary>
        public int? StartSG { get; set; }
        /// <summary>
        /// Measured end SG
        /// </summary>
        public int? EndSG { get; set; }
        /// <summary>
        /// Alcohol percentage of brewing
        /// </summary>
        public double? AlcoholPercentage { get; set; }
        /// <summary>
        /// Brew yield (L)
        /// </summary>
        public double? Yield { get; set; }
        /// <summary>
        /// IBU (bitterness)
        /// </summary>
        public double? IBU { get; set; }
        /// <summary>
        /// EBC
        /// </summary>
        public double? EBC { get; set; }
        /// <summary>
        /// Mashing Log
        /// </summary>
        public StepLog MashingLog { get; set; }
        /// <summary>
        /// Mashing Log
        /// </summary>
        public StepLog BoilingLog { get; set; }
        /// <summary>
        /// Mashing Log
        /// </summary>
        public StepLog YeastingLog { get; set; }

        public void InitializeNextStep()
        {
            if (MashingLog == null)
            {
                MashingLog = new StepLog();
            } else if (BoilingLog == null)
            {
                MashingLog.End = DateTime.UtcNow;
                BoilingLog = new StepLog();
            } else if (YeastingLog == null)
            {
                BoilingLog.End = DateTime.UtcNow;
                YeastingLog = new StepLog();
            }
        }
    }

    public class StepLog
    {
        public StepLog()
        {
            TemperatureMeasurements = new List<Measurement>();
            PhMeasurements = new List<Measurement>();
            SgMeasurements = new List<Measurement>();
            Notes = string.Empty;
            Start = DateTime.UtcNow;
        }
        
        public long Id { get; set; }
        /// <summary>
        /// Start of mashing step
        /// </summary>
        [Required]
        public DateTime Start { get; set; }
        /// <summary>
        /// End of mashing step
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Mashing notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Temperature measurements
        /// </summary>
        public List<Measurement> TemperatureMeasurements { get; set; }
        /// <summary>
        /// Measurements of ph value
        /// </summary>
        public List<Measurement> PhMeasurements { get; set; }
        /// <summary>
        /// Measurements of sg value
        /// </summary>
        public List<Measurement> SgMeasurements { get; set; }
    }

    [Owned]
    public class Measurement
    {
        public Measurement()
        {
            Notes = string.Empty;
        }
        
        public long Id { get; set; }
        /// <summary>
        /// Measurement value
        /// </summary>
        [Required]
        public double Value { get; set; }
        /// <summary>
        /// Time the measurement was taken
        /// </summary>
        [Required]
        public DateTime Time { get; set; }
        /// <summary>
        /// Notes for the measurement
        /// </summary>
        public string Notes { get; set; }
    }
}
