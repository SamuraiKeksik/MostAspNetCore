using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MostLib
{
    public class Route
    {
        [Key]
        public Guid RouteId { get; set; }

        [Required]
        [ForeignKey(nameof(Driver))]
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }

        [Required]
        [ForeignKey(nameof(Transport))]
        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }

        [ForeignKey(nameof(Trailer))]
        public Guid? TrailerId { get; set; }  
        public Trailer? Trailer { get; set; }  //Если трейлер не используется в маршруте, то null

        [Required]
        public List<Building> Buildings { get; set; } //хранит список точек назначения (зданий)

        [Required]
        public List<Cargo> Cargos { get; set; } //Хранит справочник из товаров и их количества

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил маршрут
    }
}
