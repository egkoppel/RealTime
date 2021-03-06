﻿// <copyright file="RealTimeConfig.cs" company="dymanoid">
// Copyright (c) dymanoid. All rights reserved.
// </copyright>

namespace RealTime.Config
{
    using SkyTools.Configuration;
    using SkyTools.Tools;
    using SkyTools.UI;

    /// <summary>
    /// The mod's configuration.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1708:IdentifiersShouldDifferByMoreThanCase", Justification = "Property will be removed later")]
    public sealed class RealTimeConfig : IConfiguration
    {
        /// <summary>The storage ID for the configuration objects.</summary>
        public const string StorageId = "RealTimeConfiguration";

        private const int LatestVersion = 2;

        /// <summary>Initializes a new instance of the <see cref="RealTimeConfig"/> class.</summary>
        public RealTimeConfig()
        {
            ResetToDefaults();
        }

        /// <summary>Initializes a new instance of the <see cref="RealTimeConfig"/> class.</summary>
        /// <param name="latestVersion">if set to <c>true</c>, the latest version of the configuration will be created.</param>
        public RealTimeConfig(bool latestVersion)
            : this()
        {
            if (latestVersion)
            {
                Version = LatestVersion;
            }
        }

        /// <summary>Gets or sets the version number of this configuration.</summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the speed of the time flow on daytime. Valid values are 1..7.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "DayTime", Justification = "Reviewed")]
        [ConfigItem("1General", "0Time", 2)]
        [ConfigItemSlider(1, 500, ValueType = SliderValueType.Default)]
        public uint DayTimeSpeed { get; set; }

        /// <summary>
        /// Gets or sets the speed of the time flow on night time. Valid values are 1..7.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NightTime", Justification = "Reviewed")]
        [ConfigItem("1General", "0Time", 3)]
        [ConfigItemSlider(1, 500, ValueType = SliderValueType.Default)]
        public uint NightTimeSpeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dynamic day length is enabled.
        /// The dynamic day length depends on map's location and day of the year.
        /// </summary>
        [ConfigItem("1General", "0Time", 4)]
        [ConfigItemCheckBox]
        public bool IsDynamicDayLengthEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the weekends are enabled. Cims don't go to work on weekends.
        /// </summary>
        [ConfigItem("1General", "0Time", 5)]
        [ConfigItemCheckBox]
        public bool IsWeekendEnabled { get; set; }

        /// <summary>
        /// Gets or sets the virtual citizens mode.
        /// </summary>
        [ConfigItem("1General", "1Other", 0)]
        [ConfigItemComboBox]
        public VirtualCitizensLevel VirtualCitizens { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the citizens aging and birth rates must be slowed down.
        /// </summary>
        [ConfigItem("1General", "1Other", 1)]
        [ConfigItemCheckBox]
        public bool UseSlowAging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the construction sites should pause at night time.
        /// </summary>
        [ConfigItem("1General", "1Other", 2)]
        [ConfigItemCheckBox]
        public bool StopConstructionAtNight { get; set; }

        /// <summary>
        /// Gets or sets the percentage value of the building construction speed. Valid values are 1..100.
        /// </summary>
        [ConfigItem("1General", "1Other", 3)]
        [ConfigItemSlider(1, 100)]
        public uint ConstructionSpeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the inactive buildings should switch off the lights at night time.
        /// </summary>
        [ConfigItem("1General", "1Other", 4)]
        [ConfigItemCheckBox]
        public bool SwitchOffLightsAtNight { get; set; }

        /// <summary>Gets or sets a value indicating whether a citizen can abandon a journey when being too long in
        /// a traffic congestion or waiting too long for public transport.</summary>
        [ConfigItem("1General", "1Other", 5)]
        [ConfigItemCheckBox]
        public bool CanAbandonJourney { get; set; }

        /// <summary>
        /// Gets or sets a value that determines the percentage of the Cims that will work second shift.
        /// Valid values are 1..8.
        /// </summary>
        [ConfigItem("2Quotas", 0)]
        [ConfigItemSlider(1, 25)]
        public uint SecondShiftQuota { get; set; }

        /// <summary>
        /// Gets or sets a value that determines the percentage of the Cims that will work night shift.
        /// Valid values are 1..8.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NightShift", Justification = "Reviewed")]
        [ConfigItem("2Quotas", 1)]
        [ConfigItemSlider(1, 25)]
        public uint NightShiftQuota { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the Cims that will go out for lunch.
        /// Valid values are 0..100.
        /// </summary>
        [ConfigItem("2Quotas", 2)]
        [ConfigItemSlider(0, 100)]
        public uint LunchQuota { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the population that will search locally for buildings.
        /// Valid values are 0..100.
        /// </summary>
        [ConfigItem("2Quotas", 3)]
        [ConfigItemSlider(0, 100)]
        public uint LocalBuildingSearchQuota { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the Cims that will go shopping just for fun without needing to buy something.
        /// Valid values are 0..100.
        /// </summary>
        [ConfigItem("2Quotas", 4)]
        [ConfigItemSlider(0, 50)]
        public uint ShoppingForFunQuota { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the Cims that will go to and leave their work or school
        /// on time (no overtime!).
        /// Valid values are 0..100.
        /// </summary>
        [ConfigItem("2Quotas", 5)]
        [ConfigItemSlider(0, 100)]
        public uint OnTimeQuota { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the custom events are enabled.
        /// </summary>
        [ConfigItem("3Events", 0)]
        [ConfigItemCheckBox]
        public bool AreEventsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the earliest event on a week day can start.
        /// </summary>
        [ConfigItem("3Events", 1)]
        [ConfigItemSlider(0, 23.5f, 0.5f, ValueType = SliderValueType.Time)]
        public float EarliestHourEventStartWeekday { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the latest event on a week day can start.
        /// </summary>
        [ConfigItem("3Events", 2)]
        [ConfigItemSlider(0, 23.5f, 0.5f, ValueType = SliderValueType.Time)]
        public float LatestHourEventStartWeekday { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the earliest event on a Weekend day can start.
        /// </summary>
        [ConfigItem("3Events", 3)]
        [ConfigItemSlider(0, 23.5f, 0.5f, ValueType = SliderValueType.Time)]
        public float EarliestHourEventStartWeekend { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the latest event on a Weekend day can start.
        /// </summary>
        [ConfigItem("3Events", 4)]
        [ConfigItemSlider(0, 23.5f, 0.5f, ValueType = SliderValueType.Time)]
        public float LatestHourEventStartWeekend { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the city wakes up.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "WakeUp", Justification = "Reviewed")]
        [ConfigItem("4Time", 0)]
        [ConfigItemSlider(4f, 8f, 0.25f, ValueType = SliderValueType.Time)]
        public float WakeUpHour { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the city goes to sleep.
        /// </summary>
        [ConfigItem("4Time", 1)]
        [ConfigItemSlider(20f, 23.75f, 0.25f, ValueType = SliderValueType.Time)]
        public float GoToSleepHour { get; set; }

        /// <summary>
        /// Gets or sets the work start daytime hour. The adult Cims must be at work.
        /// </summary>
        [ConfigItem("4Time", 2)]
        [ConfigItemSlider(4, 11, 0.25f, ValueType = SliderValueType.Time)]
        public float WorkBegin { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the adult Cims return from work.
        /// </summary>
        [ConfigItem("4Time", 3)]
        [ConfigItemSlider(12, 20, 0.25f, ValueType = SliderValueType.Time)]
        public float WorkEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Cims should go out at lunch for food.
        /// </summary>
        [ConfigItem("4Time", 4)]
        [ConfigItemCheckBox]
        public bool IsLunchtimeEnabled { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the Cims go out for lunch.
        /// </summary>
        [ConfigItem("4Time", 5)]
        [ConfigItemSlider(11, 13, 0.25f, ValueType = SliderValueType.Time)]
        public float LunchBegin { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the Cims return from lunch back to work.
        /// </summary>
        [ConfigItem("4Time", 6)]
        [ConfigItemSlider(13, 15, 0.25f, ValueType = SliderValueType.Time)]
        public float LunchEnd { get; set; }

        /// <summary>
        /// Gets or sets the maximum overtime for the Cims. They come to work earlier or stay at work longer for at most this
        /// amount of hours. This applies only for those Cims that are not on time, see <see cref="OnTimeQuota"/>.
        /// The young Cims (school and university) don't do overtime.
        /// </summary>
        [ConfigItem("4Time", 7)]
        [ConfigItemSlider(0, 4, 0.25f, ValueType = SliderValueType.Duration)]
        public float MaxOvertime { get; set; }

        /// <summary>
        /// Gets or sets the school start daytime hour. The young Cims must be at school or university.
        /// </summary>
        [ConfigItem("4Time", 8)]
        [ConfigItemSlider(4, 10, 0.25f, ValueType = SliderValueType.Time)]
        public float SchoolBegin { get; set; }

        /// <summary>
        /// Gets or sets the daytime hour when the young Cims return from school or university.
        /// </summary>
        [ConfigItem("4Time", 9)]
        [ConfigItemSlider(11, 16, 0.25f, ValueType = SliderValueType.Time)]
        public float SchoolEnd { get; set; }

        /// <summary>
        /// Gets or sets the maximum vacation length in days.
        /// </summary>
        [ConfigItem("4Time", 10)]
        [ConfigItemSlider(0, 7, ValueType = SliderValueType.Default)]
        public uint MaxVacationLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mod should show the incompatibility notifications.
        /// </summary>
        [ConfigItem("Tools", 0)]
        [ConfigItemCheckBox]
        public bool ShowIncompatibilityNotifications { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mod should use the English-US time and date formats, if the English language is selected.
        /// </summary>
        [ConfigItem("Tools", 1)]
        [ConfigItemCheckBox]
        public bool UseEnglishUSFormats { get; set; }

        /// <summary>Checks the version of the deserialized object and migrates it to the latest version when necessary.</summary>
        public void MigrateWhenNecessary()
        {
            if (Version == 0)
            {
                SecondShiftQuota = (uint)(SecondShiftQuota * 3.125f);
                NightShiftQuota = (uint)(NightShiftQuota * 3.125f);
            }

            Version = LatestVersion;
        }

        /// <summary>Validates this instance and corrects possible invalid property values.</summary>
        public void Validate()
        {
            WakeUpHour = FastMath.Clamp(WakeUpHour, 4f, 8f);
            GoToSleepHour = FastMath.Clamp(GoToSleepHour, 20f, 23.75f);

            DayTimeSpeed = FastMath.Clamp(DayTimeSpeed, 1u, 6u);
            NightTimeSpeed = FastMath.Clamp(NightTimeSpeed, 1u, 6u);

            VirtualCitizens = (VirtualCitizensLevel)FastMath.Clamp((int)VirtualCitizens, (int)VirtualCitizensLevel.None, (int)VirtualCitizensLevel.Vanilla);
            ConstructionSpeed = FastMath.Clamp(ConstructionSpeed, 1u, 100u);

            SecondShiftQuota = FastMath.Clamp(SecondShiftQuota, 1u, 25u);
            NightShiftQuota = FastMath.Clamp(NightShiftQuota, 1u, 25u);
            LunchQuota = FastMath.Clamp(LunchQuota, 0u, 100u);
            LocalBuildingSearchQuota = FastMath.Clamp(LocalBuildingSearchQuota, 0u, 100u);
            ShoppingForFunQuota = FastMath.Clamp(ShoppingForFunQuota, 0u, 50u);
            OnTimeQuota = FastMath.Clamp(OnTimeQuota, 0u, 100u);

            EarliestHourEventStartWeekday = FastMath.Clamp(EarliestHourEventStartWeekday, 0f, 23.5f);
            LatestHourEventStartWeekday = FastMath.Clamp(LatestHourEventStartWeekday, 0f, 23.5f);
            if (LatestHourEventStartWeekday < EarliestHourEventStartWeekday)
            {
                LatestHourEventStartWeekday = EarliestHourEventStartWeekday;
            }

            EarliestHourEventStartWeekend = FastMath.Clamp(EarliestHourEventStartWeekend, 0f, 23.5f);
            LatestHourEventStartWeekend = FastMath.Clamp(LatestHourEventStartWeekend, 0f, 23.5f);
            if (LatestHourEventStartWeekend < EarliestHourEventStartWeekend)
            {
                LatestHourEventStartWeekend = EarliestHourEventStartWeekend;
            }

            WorkBegin = FastMath.Clamp(WorkBegin, 4f, 11f);
            WorkEnd = FastMath.Clamp(WorkEnd, 12f, 20f);
            LunchBegin = FastMath.Clamp(LunchBegin, 11f, 13f);
            LunchEnd = FastMath.Clamp(LunchEnd, 13f, 15f);
            SchoolBegin = FastMath.Clamp(SchoolBegin, 4f, 10f);
            SchoolEnd = FastMath.Clamp(SchoolEnd, 11f, 16f);
            MaxOvertime = FastMath.Clamp(MaxOvertime, 0f, 4f);
            MaxVacationLength = FastMath.Clamp(MaxVacationLength, 0u, 7u);
        }

        /// <summary>Resets all values to their defaults.</summary>
        public void ResetToDefaults()
        {
            WakeUpHour = 6f;
            GoToSleepHour = 22f;

            IsDynamicDayLengthEnabled = true;
            DayTimeSpeed = 4;
            NightTimeSpeed = 5;

            VirtualCitizens = VirtualCitizensLevel.Vanilla;
            UseSlowAging = true;
            IsWeekendEnabled = true;
            IsLunchtimeEnabled = true;

            StopConstructionAtNight = true;
            ConstructionSpeed = 50;
            SwitchOffLightsAtNight = true;
            CanAbandonJourney = true;

            SecondShiftQuota = 13;
            NightShiftQuota = 6;

            LunchQuota = 80;
            LocalBuildingSearchQuota = 60;
            ShoppingForFunQuota = 30;
            OnTimeQuota = 80;

            AreEventsEnabled = true;
            EarliestHourEventStartWeekday = 16f;
            LatestHourEventStartWeekday = 20f;
            EarliestHourEventStartWeekend = 8f;
            LatestHourEventStartWeekend = 22f;

            WorkBegin = 9f;
            WorkEnd = 18f;
            LunchBegin = 12f;
            LunchEnd = 13f;
            MaxOvertime = 2f;
            SchoolBegin = 8f;
            SchoolEnd = 14f;
            MaxVacationLength = 3u;

            ShowIncompatibilityNotifications = true;
        }
    }
}
