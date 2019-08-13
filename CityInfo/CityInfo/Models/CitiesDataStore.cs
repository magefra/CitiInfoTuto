using System.Collections.Generic;

namespace CityInfo.Models
{
    public class CitiesDataStore
    {

        public static CitiesDataStore Curent { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                     Id = 1,
                     Name = "Véracruz",
                     Description = "Lugar donde éxiste la playa."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Cosamaloapan",
                    Description = "Lugar de las golondrinas."
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Tlacotalpan",
                    Description = "Lugar con mucha riqueza."
                }

            };
        }

    }
}
