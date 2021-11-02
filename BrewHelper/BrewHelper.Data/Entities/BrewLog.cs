namespace BrewHelper.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public class BrewLog
    {
        public BrewLog()
        {
            this.Notes = string.Empty;
        }

        public long Id { get; set; }

        /// <summary>
        /// Recipe the brewing is based off.
        /// </summary>
        public Recipe? Recipe { get; set; }

        [Required(ErrorMessage = "Recipe is required")]
        [ForeignKey(nameof(Recipe))]
        public long RecipeId { get; set; }

        /// <summary>
        /// Brewing notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Date the brewing started.
        /// </summary>
        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date the brewing was completed.
        /// </summary>
        public DateTime? EndDate { get; set; } = null;

        /// <summary>
        /// Measured start SG.
        /// </summary>
        public int? StartSG { get; set; }

        /// <summary>
        /// Measured end SG.
        /// </summary>
        public int? EndSG { get; set; }

        /// <summary>
        /// Alcohol percentage of brewing.
        /// </summary>
        public double? AlcoholPercentage { get; set; }

        /// <summary>
        /// Brew yield (L).
        /// </summary>
        public double? Yield { get; set; }

        /// <summary>
        /// IBU (bitterness).
        /// </summary>
        public double? IBU { get; set; }

        /// <summary>
        /// EBC.
        /// </summary>
        public double? EBC { get; set; }

        /// <summary>
        /// Mashing Log.
        /// </summary>
        public StepLog? MashingLog { get; set; }

        /// <summary>
        /// Mashing Log.
        /// </summary>
        public StepLog? BoilingLog { get; set; }

        /// <summary>
        /// Mashing Log.
        /// </summary>
        public StepLog? YeastingLog { get; set; }

        public void InitializeNextStep()
        {
            if (this.MashingLog == null)
            {
                this.MashingLog = new StepLog();
            }
            else if (this.BoilingLog == null)
            {
                this.MashingLog.End = DateTime.UtcNow;
                this.BoilingLog = new StepLog();
            }
            else if (this.YeastingLog == null)
            {
                this.BoilingLog.End = DateTime.UtcNow;
                this.YeastingLog = new StepLog();
            }
        }
    }

#pragma warning disable SA1402
    public class StepLog
#pragma warning restore SA1402
    {
        public StepLog()
        {
            this.TemperatureMeasurements = new List<Measurement>();
            this.PhMeasurements = new List<Measurement>();
            this.SgMeasurements = new List<Measurement>();
            this.Notes = string.Empty;
            this.Start = DateTime.UtcNow;
        }

        public long Id { get; set; }

        /// <summary>
        /// Start of mashing step.
        /// </summary>
        [Required(ErrorMessage = "Start date is required")]
        public DateTime Start { get; set; }

        /// <summary>
        /// End of mashing step.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Mashing notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Temperature measurements.
        /// </summary>
        public List<Measurement> TemperatureMeasurements { get; set; }

        /// <summary>
        /// Measurements of ph value.
        /// </summary>
        public List<Measurement> PhMeasurements { get; set; }

        /// <summary>
        /// Measurements of sg value.
        /// </summary>
        public List<Measurement> SgMeasurements { get; set; }
    }

    [Owned]
#pragma warning disable SA1402
    public class Measurement
#pragma warning restore SA1402
    {
        public Measurement()
        {
            this.Notes = string.Empty;
        }

        public long Id { get; set; }

        /// <summary>
        /// Measurement value.
        /// </summary>
        [Required(ErrorMessage = "Measurement value is required")]
        public double Value { get; set; }

        /// <summary>
        /// Time the measurement was taken.
        /// </summary>
        [Required(ErrorMessage = "Measurement time is required")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Notes for the measurement.
        /// </summary>
        public string Notes { get; set; }
    }
}