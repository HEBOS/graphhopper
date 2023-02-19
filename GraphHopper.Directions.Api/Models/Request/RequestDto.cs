namespace GraphHopper.Directions.Api.Models.Request
{
    public class RequestDto
    {
        public List<Vehicle> vehicles { get; set; }
        public List<VehicleType> vehicle_types { get; set; }
        public List<Service> services { get; set; }
        public List<Shipment> shipments { get; set; }
        public List<Objective> objectives { get; set; }
        public Configuration configuration { get; set; }
    }
}
