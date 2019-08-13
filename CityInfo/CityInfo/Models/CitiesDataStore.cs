using System.Collections.Generic;

namespace CityInfo.Models
{
    public class CitiesDataStore
    {
        /// <summary>
        /// 
        /// </summary>
        public static CitiesDataStore Curent { get; } = new CitiesDataStore();

        /// <summary>
        /// 
        /// </summary>
        public List<CityDto> Cities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                     Id = 1,
                     Name = "Véracruz",
                     Description = "Lugar donde éxiste la playa.",
                     PointOfInterest = new List<PointsOfInterestDto>()
                     {
                         new PointsOfInterestDto()
                         {
                             Id = 1,
                             Name = "Acuario",
                             Description = "Lugar dónde se encuentra una varia de especies."
                         },
                         new PointsOfInterestDto()
                         {
                             Id = 2,
                             Name = "Playa",
                             Description = "Lugar para ir a bañarse"
                         }
                     }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Cosamaloapan",
                    Description = "Lugar de las golondrinas.",
                     PointOfInterest = new List<PointsOfInterestDto>()
                     {
                         new PointsOfInterestDto()
                         {
                             Id = 1,
                             Name = "Parque central",
                             Description = "Lugar para pasar un rato descansando"
                         }

                     }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Tlacotalpan",
                    Description = "Lugar con mucha riqueza.",
                     PointOfInterest = new List<PointsOfInterestDto>()
                     {
                         new PointsOfInterestDto()
                         {
                             Id = 1,
                             Name = "Mariscos",
                             Description = "Lugar dónde encontraras restaurantes de todo tipo"
                         }
                     }
                }

            };
        }

    }
}
