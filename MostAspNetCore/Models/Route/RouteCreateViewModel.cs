
using Microsoft.AspNetCore.Mvc.Rendering;
using MostLib;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MostAspNetCore.Models.Route
{
    public class RouteCreateViewModel
    {
        
        public SelectList? DriversList { get; set; }
        [DisplayName("Водитель")]
        public Guid SelectedDriverId { get; set; }

        public SelectList? TransportsList { get; set; }
        [DisplayName("Транспорт")]
        public Guid SelectedTransportId { get; set; }        

        public SelectList? TrailersList { get; set; }
        [DisplayName("Прицеп")]
        public Guid SelectedTrailerId { get; set; }

        public SelectList? BuildingsList { get; set; }
        [DisplayName("Начальное здание")]
        public Guid SelectedStartBuildingId { get; set; }
        [DisplayName("Конечное здание")]
        public Guid SelectedEndBuildingId { get; set; }

        public List<MostLib.Cargo> CargosList { get; set; } = new List<Cargo>();


    }
}
