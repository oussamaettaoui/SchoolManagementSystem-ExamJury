using SchoolManagementSystem.Domain.Dtos.SectorDtos;

namespace SchoolManagementSystem.Domain.Entities
{
    public static class SectorStore
    {
        public static List<SectorDto> sectorList = new List<SectorDto>{
            new SectorDto
            {
                SectorId = 1,
                SectorName = "Administration, Gestion et Commerce"
            },
            new SectorDto
            {
                SectorId = 2,
                SectorName = "Technique d’Information et de Communication"
            }
        };

    }
}
