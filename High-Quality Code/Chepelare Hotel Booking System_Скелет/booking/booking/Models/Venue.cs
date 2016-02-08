﻿namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Utilities;

    public class Venue : IDbEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public User Owner { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinVenueNameLength)
                {
                    throw new ArgumentException(string.Format("The venue name must be at least {0} symbols long.", Constants.MinVenueNameLength));
                }

                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinVenueAddressLength)
                {
                    throw new ArgumentException(string.Format("The venue address must be at least {0} symbols long.", Constants.MinVenueAddressLength));
                }

                this.address = value;
            }
        }
    }
}
